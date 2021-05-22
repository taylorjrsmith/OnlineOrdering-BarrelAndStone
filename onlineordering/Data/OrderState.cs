using BlazingPizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class OrderState
    {
        public bool ShowingConfigureDialog { get; private set; }
        public bool ShowingDrinkDialog { get; set; }
        public bool ShowMobileOrderBreakdown { get; set; }
        public Pizza ConfiguringPizza { get; private set; }
        public bool IsDelivery { get; set; }
        public DrinkOrderItem ConfiguringDrink { get; private set; }
        public Order Order { get; private set; } = new Order();

        public void ShowConfigurePizzaDialog(PizzaSpecial special)
        {
            ConfiguringPizza = new Pizza()
            {
                Special = special,
                SpecialId = special.Id,
                Size = Pizza.DefaultSize,
                Toppings = new List<PizzaTopping>(),
            };

            ShowingConfigureDialog = true;
        }

        public void ShowConfigureDrinkDialog(Drink drink)
        {
            ConfiguringDrink = new DrinkOrderItem()
            {
                Drink = drink,
                DrinkId = drink.Id
            };

            ShowingDrinkDialog = true;
        }

        public void CancelConfigurePizzaDialog()
        {
            ConfiguringPizza = null;
            ShowingConfigureDialog = false;
        }
        public void CancelConfigureDrinkDialog()
        {
            ConfiguringDrink = null;
            ShowingDrinkDialog = false;
        }

        public void ConfirmConfigurePizzaDialog()
        {
            Order.Pizzas.Add(ConfiguringPizza);
            ConfiguringPizza = null;

            ShowingConfigureDialog = false;
        }

        public void ConfirmConfigureDrinkDialog()
        {
            Order.Drinks.Add(ConfiguringDrink);
            ConfiguringDrink = null;

            ShowingDrinkDialog = false;
        }


        public void RemoveConfiguredPizza(Pizza pizza)
        {
            Order.Pizzas.Remove(pizza);
        }

        public void RemoveConfiguredDrink(DrinkOrderItem drink)
        {
            Order.Drinks.Remove(drink);
        }

        public void ResetOrder()
        {
            Order = new Order();
        }

        public void ReplaceOrder(Order order)
        {
            Order = order;
        }
    }
}