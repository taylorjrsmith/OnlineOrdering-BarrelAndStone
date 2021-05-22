using BlazingPizza;
using BlazorApp1.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class ManagementService
    {
        private PizzaStoreContext _db;
        private readonly IConfiguration _configuration;
        private readonly CacheHelper _cacheHelper;

        public ManagementService(PizzaStoreContext db, IConfiguration config, CacheHelper cacheHelper)
        {
            _db = db;
            _configuration = config;
            _cacheHelper = cacheHelper;
        }

        public async Task<List<PizzaSpecial>> GetPizzaSpecials()
        {
            var specials = await _db.Specials.ToListAsync();
            return specials;
        }

        public async Task<List<Drink>> GetDrinks()
        {
            var drinks = await _db.Drinks.ToListAsync();
            return drinks;
        }



        public async Task<PizzaSpecial> GetPizzaSpecial(int id)
        {
            var special = await _db.Specials.FirstOrDefaultAsync(a => a.Id == id);
            return special;
        }

        public async Task<Drink> GetDrink(int id)
        {
            var drink = await _db.Drinks.FirstOrDefaultAsync(a => a.Id == id);
            return drink;
        }


        public async Task DeleteSpecial(PizzaSpecial special)
        {
            _db.Specials.Remove(special);
            await _db.SaveChangesAsync();
        }

        public async Task<Dictionary<string,string>> MostValuedCustomer()
        {
            var orders = _db.Orders.ToList();
            var customers = new Dictionary<string, int>();
            foreach(var o in orders)
            {
                var number = o.Number.Replace(" ", "");
                if (customers.ContainsKey(number))
                {
                    customers[number]++;
                }
                else
                {
                    customers.Add(number, 1);
                }
               


            }
            var highestValue = customers.Values.Distinct().OrderByDescending(a => a).FirstOrDefault();
            var highestNumbers = customers.Where(a => a.Value == highestValue);
            var mvc = orders.Where(a => highestNumbers.Any(b => b.Key == a.Number.Replace(" ", ""))).Select(a => new KeyValuePair<string,string>(a.Name.Split(" ").FirstOrDefault().Trim(),a.Number.Replace(" ", ""))).Distinct().ToDictionary(a => a.Key, b => b.Value);
            return mvc;


        }

        public async Task DeleteDrink(Drink drink)
        {
            _db.Drinks.Remove(drink);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateSpecial(PizzaSpecial special)
        {
            if (special.Id != 0)
                _db.Update(special);
            else
                _db.Add(special);
            await _db.SaveChangesAsync();
            _cacheHelper.ClearCache(CacheKeys.AllSpecials);
        }

        public async Task UpdateDrink(Drink drink)
        {
            if(drink.Id != 0)
            {
                _db.Update(drink);
            }
            else
            {
                _db.Add(drink);
            }

            await _db.SaveChangesAsync();
        }

        public async Task UpdateEvent(SpecialEventCategory cat)
        {
            _db.Update(cat);
            await _db.SaveChangesAsync();
        }

        public async Task<SpecialEventCategory> GetEventCategory(string catName)
        {
            return await _db.SpecialEventCategories.FirstOrDefaultAsync(a => a.CategoryName == catName);
        }

    }
}
