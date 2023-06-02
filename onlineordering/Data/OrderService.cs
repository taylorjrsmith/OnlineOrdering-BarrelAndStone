using BlazingPizza;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using TKGroup.Settings;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace BlazorApp1.Data
{
    public class OrderService
    {
        private PizzaStoreContext _db;
        private readonly IConfiguration _configuration;
        private readonly CacheHelper _cacheHelper;
        private readonly TKGroup.Settings.ISettingService settingsService;

        public OrderService(PizzaStoreContext db, IConfiguration config, CacheHelper cacheHelper, TKGroup.Settings.ISettingService _settingService)
        {
            _db = db;
            _configuration = config;
            _cacheHelper = cacheHelper;
            settingsService = _settingService;
        }


        public async Task<List<Topping>> GetToppings()
        {
            return await _db.Toppings.Where(a => !a.IsDeleted).OrderBy(t => t.Name).ToListAsync();
        }

        public async Task MarkOrderAsDone(int id)
        {
            var order = _db.Orders.FirstOrDefault(a => a.OrderId == id);
            order.Status = "Done";
            _db.Update(order);
            await _db.SaveChangesAsync();
        }

        public async Task<NewOrderResult> PlaceOrder(Order order, bool isDelivery)
        {
            bool modification = false;
            if (order.OrderId != 0)
            {
                var newFoundOrder = _db.Orders.FirstOrDefault(o => o.OrderId == order.OrderId);
                _db.Orders.Remove(newFoundOrder);
                await _db.SaveChangesAsync();
            }
            order.CreatedTime = DateTime.Now; ;

            foreach (var drink in order.Drinks)
            {
                drink.Id = 0;
                drink.DrinkId = drink.DrinkId;
                drink.Drink = null;
            }
            // Enforce existence of Pizza.SpecialId and Topping.ToppingId
            // in the database - prevent the submitter from making up
            // new specials and toppings
            foreach (var pizza in order.Pizzas)
            {
                pizza.Id = 0;
                pizza.SpecialId = pizza.Special.Id;
                pizza.Special = null;

                foreach (var topping in pizza.Toppings)
                {
                    topping.PizzaId = 0;
                    topping.ToppingId = topping.Topping.Id;
                    topping.Topping = null;
                }
            }
            if (order.OrderId > 0)
            {
                modification = true;
                order.OrderId = 0;
            }

            _db.Orders.Attach(order);

            await _db.SaveChangesAsync();
            if (order.Status == "Ordered" && _configuration.GetValue<bool>("TextMessaging", false))
            {
                var sid = _configuration.GetValue<string>("Twilio:sid");
                var auth = _configuration.GetValue<string>("Twilio:auth");
                var hostUrl = _configuration.GetValue<string>("hostUrl");

                TwilioClient.Init(sid, auth);
                var textMessage = "";
                if (modification)
                    textMessage = $"Thank you for your modification for your takeaway from the Gate, Bricket Wood. Your new 'manage my order' link is {hostUrl}/myorders/{order.OrderId}/{order.Password}";
                else
                {
                    if (!isDelivery)
                    {
                        //textMessage = $"Thank you for ordering your takeaway from The Gate, Bricket Wood. Your timeslot is {order.CollectionDate.ToString("HH:mm")} on {order.CollectionDate.DayOfWeek.ToString()} {order.CollectionDate.ToString("dd MMMM")}. You can manage your order by visiting {hostUrl}/myorders/{order.OrderId}/{order.Password}";
                        textMessage = $"Thank you for ordering your takeaway from The Gate, Bricket Wood. Please wait in the car park @{order.CollectionDate.ToString("HH:mm")} on {order.CollectionDate.DayOfWeek.ToString()} {order.CollectionDate.ToString("dd MMMM")}";
                        var message = MessageResource.Create(body: textMessage,
                          from: new Twilio.Types.PhoneNumber("+447380329037"),
                          to: new Twilio.Types.PhoneNumber(order.Number));
                    }
                    if (isDelivery)
                    {
                        //textMessage = $"Thank you for ordering your takeaway from The Gate, Bricket Wood. Your timeslot is {order.CollectionDate.ToString("HH:mm")} on {order.CollectionDate.DayOfWeek.ToString()} {order.CollectionDate.ToString("dd MMMM")}. You can manage your order by visiting {hostUrl}/myorders/{order.OrderId}/{order.Password}";
                        textMessage = $"Thank you for your order, We will call you 30 mins prior to your delivery at {order.CollectionDate.ToString("HH:mm")} on {order.CollectionDate.ToString("dd MMMM")} to arrange payment.";
                        var message = MessageResource.Create(body: textMessage,
                          from: new Twilio.Types.PhoneNumber("+447380329037"),
                          to: new Twilio.Types.PhoneNumber(order.Number));
                    }
                }


            }

            return new NewOrderResult() { Password = order.Password, OrderId = order.OrderId };
        }

        public async Task<Dictionary<string, double>> GetOpeningTimes()
        {
            Dictionary<string, double> openingTimes = new Dictionary<string, double>();
            openingTimes.Add("open", _configuration.GetValue<double>("OpeningHours:Open"));
            openingTimes.Add("close", _configuration.GetValue<double>("OpeningHours:Close"));
            return openingTimes;
        }

        public async Task<List<OrderWithStatus>> GetOrders(int day, int month, int year)
        {
            var date = new DateTime(year, month, day);

            var orders = await _db.Orders
                .Where(o => o.CollectionDate.Date == date.Date)
                .Include(o => o.Pizzas).ThenInclude(p => p.Special)
                .Include(o => o.Drinks).ThenInclude(d => d.Drink)
                .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping)
                .OrderByDescending(o => o.CreatedTime)
                .ToListAsync();

            return orders.Select(o => OrderWithStatus.FromOrder(o)).ToList();
        }

        public async Task<List<PizzaSpecial>> GetSpecials()
        {
            return _cacheHelper.GetFromCache<List<PizzaSpecial>>("Pizza|Specials|All", () => _db.Specials.Where(a => a.IsEnabled).ToList().OrderByDescending(s => s.BasePrice).ToList());
        }


        public async Task CancelOrder(int orderId, string orderPassword)
        {
            var order = _db.Orders.FirstOrDefault(a => a.OrderId == orderId && a.Password == orderPassword);
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Drink>> GetDrinks()
        {
            return (await _db.Drinks.ToListAsync()).OrderByDescending(s => s.DrinkName).ToList();
        }



        public async Task<OrderWithStatus> GetOrderWithStatus(int orderId, string orderPassword)
        {
            var order = await _db.Orders
                .Where(o => o.OrderId == orderId && o.Password == orderPassword)
                .Include(o => o.Drinks).ThenInclude(d => d.Drink)
                .Include(o => o.Pizzas).ThenInclude(p => p.Special)
                .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping)
                .SingleOrDefaultAsync();

            if (order == null)
            {
                return null;
            }

            return OrderWithStatus.FromOrder(order);
        }

        public async Task<KitchenInfo> GetTodaysRevenue(int day, int month, int year)
        {
            var today = new DateTime(year, month, day, 0, 0, 0, 1);
            var orders = await _db.Orders.Include(o => o.Drinks).ThenInclude(d => d.Drink)
                .Include(o => o.Pizzas).ThenInclude(p => p.Special)
                .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping).Where(a => a.CollectionDate.Date == today.Date).ToListAsync();
            var income = orders.Sum(a => a.GetTotalPrice());

            var kitchenInfo = new KitchenInfo();
            kitchenInfo.TotalIncome = income;
            var pizzaDict = new Dictionary<string, int>();
            var PizzaSpecials = orders.SelectMany(a => a.Pizzas.Where(b => b.IsSide)).ToList();
            foreach (var p in PizzaSpecials)
            {
                if (pizzaDict.ContainsKey(p.Special.Name))
                {
                    var val = pizzaDict[p.Special.Name];
                    pizzaDict[p.Special.Name] = (val + 1);
                }
                else
                {
                    pizzaDict.Add(p.Special.Name, 1);
                }

            }

            var glutenFree = orders.SelectMany(a => a.Pizzas.Where(a => a.GlutenFree)).Count();
            var eightInch = orders.SelectMany(a => a.Pizzas.Where(a => a.Size == 8 && !a.IsSide)).Count();
            var TwelveInch = orders.SelectMany(a => a.Pizzas.Where(a => a.Size == 12 && !a.GlutenFree)).Count();

            kitchenInfo.GlutenFree = glutenFree;
            kitchenInfo.EightInch = eightInch;
            kitchenInfo.TwelveInch = TwelveInch;
            kitchenInfo.TodaysSales = pizzaDict;
            kitchenInfo.TotalPizzas = orders.SelectMany(a => a.Pizzas.Where(b => !b.IsSide)).Count();

            var drinkDict = new Dictionary<string, int>();
            var drinks = orders.SelectMany(a => a.Drinks).ToList();
            foreach (var d in drinks)
            {
                if (drinkDict.ContainsKey(d.Drink.DrinkName))
                {
                    var val = drinkDict[d.Drink.DrinkName];
                    drinkDict[d.Drink.DrinkName] = (val + 1);
                }
                else
                {
                    drinkDict.Add(d.Drink.DrinkName, 1);
                }
            }
            kitchenInfo.Drinks = drinkDict;
            return kitchenInfo;
        }

        public Dictionary<string, decimal> GetSalesGroups(DateTime startDate, DateTime endDate)
        {
            startDate = startDate.Date;
            endDate = endDate.Date;
            startDate = startDate.AddMinutes(1);
            endDate = endDate.AddHours(23).AddMinutes(59);
            var dict = new Dictionary<string, decimal>();
            var pizzaSales = _db.Orders.Where(a => a.CollectionDate > startDate && a.CollectionDate < endDate).Include(o => o.Pizzas).ThenInclude(p => p.Special).Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping).SelectMany(a => a.Pizzas).ToList().Sum(a => a.GetTotalPrice());
            dict.Add("Food", pizzaSales);
            var drinkSales = _db.Orders.Include(o => o.Drinks).ThenInclude(d => d.Drink).ToList().Where(a => a.CollectionDate > startDate && a.CollectionDate < endDate).SelectMany(a => a.Drinks).Where(a => a.Drink.ReportingCategory == "Alcoholic").Sum(a => a.Price);
            dict.Add("Alcoholic", drinkSales);
            var softDrinkSales = _db.Orders.Include(o => o.Drinks).ThenInclude(d => d.Drink).ToList().Where(a => a.CollectionDate > startDate && a.CollectionDate < endDate).SelectMany(a => a.Drinks).Where(a => a.Drink.ReportingCategory == "Non Alcoholic").Sum(a => a.Price);
            dict.Add("Non Alcoholic", softDrinkSales);
            return dict;
        }

        public async Task<decimal> GetLast7DaysIncome()
        {
            var orders = await _db.Orders.Include(o => o.Pizzas).ThenInclude(p => p.Special).Include(o => o.Drinks).ThenInclude(d => d.Drink).Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping).Where(a => a.CollectionDate > DateTime.Now.AddDays(-7) && a.CollectionDate < DateTime.Now).ToListAsync();
            return orders.Sum(a => a.GetTotalPrice());
        }

        public async Task<decimal> GetLastXDaysIncome(int x)
        {
            var orders = await _db.Orders.Include(o => o.Pizzas).ThenInclude(p => p.Special).Include(o => o.Drinks).ThenInclude(d => d.Drink).Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping).Where(a => a.CollectionDate > DateTime.Now.AddDays(x) && a.CollectionDate < DateTime.Now).ToListAsync();
            return orders.Sum(a => a.GetTotalPrice());
        }

        public async Task<List<Timeslot>> GetEventTimeslots(SpecialEventCategory category)
        {
            var orders = _db.Orders.Include(o => o.Pizzas).ThenInclude(p => p.Special).Where(a => a.CollectionDate.Date == category.EventDate.Date).ToList();

            List<Timeslot> timeslots = new List<Timeslot>();
            (int hour, int min) open = (Convert.ToInt32(category.StartTime.Split(":")[0]), Convert.ToInt32(category.StartTime.Split(":")[1]));
            (int hour, int min) closed = (Convert.ToInt32(category.EndTime.Split(":")[0]), Convert.ToInt32(category.EndTime.Split(":")[1]));
            var openTime = category.EventDate.AddHours(open.hour).AddMinutes(open.min);
            var closeTime = category.EventDate.AddHours(closed.hour).AddMinutes(closed.min);
            var timeslotInterval = category.TimeslotInterval;
            var slot = openTime;
            while(slot < closeTime)
            {
                if (IsEventSlotAvailable(orders, slot).Result)
                    timeslots.Add(new Timeslot() { Date = slot, Time = slot.ToString("HH:mm") });
                slot = slot.AddMinutes(timeslotInterval);
            }
            return timeslots;

        }

        private async Task<bool> IsEventSlotAvailable(List<Order> Orders, DateTime proposedSlot)
        {
            if (Orders.Any(a => a.CollectionDate == proposedSlot))
                return false;
            return true;
        }

        public async Task<List<Timeslot>> GetAvailableTimeslots(int day, int month, int year, int numberOfPizzas, int numberOfRestrictedItems)
        {

            DateTime collectionDate = new DateTime(year, month, day, 0, 0, 0, 0);

            var orders = _db.Orders.Include(o => o.Pizzas).ThenInclude(p => p.Special).Where(a => a.CollectionDate.Date == collectionDate.Date).ToList();
            List<Timeslot> timeslots = new List<Timeslot>();
            var openTimeSetting = await settingsService.GetSetting<double>($"WorkingHours:{collectionDate.DayOfWeek}:Open", 16.5);
            var closeTimeSetting = await settingsService.GetSetting<double>($"WorkingHours:{collectionDate.DayOfWeek}:Closed", 20.5);
            var openTime = collectionDate.AddHours(openTimeSetting);
            var closeTime = collectionDate.AddHours(closeTimeSetting);
            var timeslotDistance = await settingsService.GetSetting<int>($"KitchenSettings:{collectionDate.DayOfWeek}:Interval", 10);
            var slot = openTime;
            while (slot < closeTime)
            {
                if (await IsSlotAvailable(orders, slot, timeslotDistance, numberOfPizzas, numberOfRestrictedItems))//check if previous order contains 6 or more pizzas, check if minutes = 05 or 00, also check if order.count of pizzas is less than 2
                {
                    if (slot >= DateTime.Now.AddMinutes(timeslotDistance * 2))
                        timeslots.Add(new Timeslot() { Date = slot, Time = slot.ToString("HH:mm") });
                }
                slot = slot.AddMinutes(timeslotDistance);
            }
            return timeslots;
        }


        public async Task<List<DateTime>> GetDates()
        {
            List<DateTime> dates = new List<DateTime>();
            DateTime date = DateTime.Now.Date;
            string closedDays = await this.settingsService.GetSetting<string>("KitchenSettings:ClosedDays", (object)"Monday,Tuesday,Wednesday");
            List<DateTime> holidayDates = await this.GetHolidayDates();
            List<string> list = ((IEnumerable<string>)closedDays.Split(',')).ToList<string>();
            for (int index = 0; index <= 14; ++index)
            {
                if (list.Any<string>((Func<string, bool>)(a => a == date.DayOfWeek.ToString())) || holidayDates.Any<DateTime>((Func<DateTime, bool>)(a => a.Date == date)))
                {
                    date = date.AddDays(1.0);
                }
                else
                {
                    dates.Add(date);
                    date = date.AddDays(1.0);
                }
            }
            List<DateTime> dateTimeList = dates;
            dates = (List<DateTime>)null;
            closedDays = (string)null;
            return dateTimeList;
        }

        public async Task<List<DateTime>> GetHolidayDates()
        {
            string[] strArray = (await this.settingsService.GetSetting<string>("HolidayDates","")).Split(",");
            List<DateTime> dateTimeList = new List<DateTime>();
            foreach (string str in strArray)
            {
                try
                {
                    DateTime dateTime = Convert.ToDateTime(str, (IFormatProvider)new CultureInfo("en-GB"));
                    dateTimeList.Add(dateTime);
                }catch(Exception ex)
                {

                }
            }
            return dateTimeList;
        }

        public async Task<bool> IsSlotAvailable(List<Order> Orders, DateTime proposedSlot, int timeslotDistance, int nop, int numberOfRestrictedItems)
        {

            var maxPizzaBlockingInterval = await settingsService.GetSetting<int>($"KitchenSettings:MaxPizzaBlockingInterval", 5);
            //check if previous order contains 6 or more pizzas
            if (timeslotDistance == maxPizzaBlockingInterval)
            {
                var negative = maxPizzaBlockingInterval * (-1);

                if (Orders.Any(a => a.CollectionDate == proposedSlot.AddMinutes(negative)))
                {
                    var order = Orders.FirstOrDefault(a => a.CollectionDate == proposedSlot.AddMinutes(negative));
                    var maxPizzaCountToBlockNextOrder = await settingsService.GetSetting<int>("KitchenSettings:MaxNumberOfPizzasToBlockNext", 6);
                    if (order.Pizzas.Count >= maxPizzaBlockingInterval)
                        return false;
                }

                var blockedMinutes = await settingsService.GetSetting<string>("KitchenSettings:Timeslot:CatchupMinutes", "00");
                List<string> mins = blockedMinutes.Split(',').ToList();

                if (mins.Any(a => a == proposedSlot.ToString("mm")))
                    return false;
            }

            if (Orders.Any(a => a.CollectionDate == proposedSlot))
            {
                var ordersInSlot = Orders.Where(a => a.CollectionDate == proposedSlot).Count();
                var maxNumberOfOrdersPerSlot = await settingsService.GetSetting<int>("kitchenSettings:NumberOfOrdersPerTimeslot", 2);
                if (ordersInSlot >= maxNumberOfOrdersPerSlot)
                    return false;
                var maxnopfirstOrder = await settingsService.GetSetting<int>("KitchenSettings:NumberOfPizzasToAllowSecondOrder", 2);
                var maxnopAllowedInSecondOrder = await settingsService.GetSetting<int>("KitchenSettings:NumberOfPizzasAllowedInSecondOrder", 3);
                var maxnoRestrictedItems = await settingsService.GetSetting<int>("KitchenSettings:NumberOfRestrictedItemsAllowedInOrder", 4);
                var ordersPizzaCount = Orders.Where(a => a.CollectionDate == proposedSlot).SelectMany(a => a.Pizzas.Where(p => !p.IsSide)).Count();
                var restrictedCount = Orders.Where(a => a.CollectionDate == proposedSlot).SelectMany(a => a.Pizzas.Where(p => p.IsRestricted)).Count();
                if (ordersPizzaCount <= maxnopfirstOrder && nop <= maxnopAllowedInSecondOrder)
                {
                    var totalrestrictioncount = (restrictedCount + numberOfRestrictedItems);
                    return totalrestrictioncount < maxnoRestrictedItems;

                }
                else
                    return false;
            }

            return true;

        }


    }
}
