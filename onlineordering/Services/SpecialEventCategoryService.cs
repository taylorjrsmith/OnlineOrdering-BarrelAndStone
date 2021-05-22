using BlazingPizza;
using BlazorApp1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public class SpecialEventCategoryService
    {

        PizzaStoreContext Context { get; set; }

        public SpecialEventCategoryService(PizzaStoreContext pizzaStoreContext)
        {
            Context = pizzaStoreContext;
        }

        public bool IsPotentiallyElegibleForFreeDelivery(SpecialEventCategory eventCategory, decimal totalPrice)
        {
            if (totalPrice>= eventCategory.FreeDeliveryThreshold)
                return true;
            return false;
        }

        public bool CheckFreeDeliveryEligibility(string postcode, SpecialEventCategory eventCategory)
        {
            var normalisedPostcode = postcode.Replace(" ", "").ToLower();
            if (eventCategory.LimitedPostcodes.Any(a => normalisedPostcode.StartsWith(a.ToLower().Replace(" ", ""))))
            {
                return true;
            }
            return false;

        }

    }
}
