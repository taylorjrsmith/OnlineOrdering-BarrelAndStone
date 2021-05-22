using BlazingPizza;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKGroup.Settings;

namespace BlazorApp1.Data
{
    public class PizzaStoreContext :DbContext, ISettingDbContext
    {
        public PizzaStoreContext(
            DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<PizzaSpecial> Specials { get; set; }
        public DbSet<DrinkOrderItem> DrinkItems { get; set; }
        public DbSet<SpecialEventCategory> SpecialEventCategories { get; set; }
        public DbSet<EventCategoryItemMapper> EventCategoryItemMappers { get; set; }

        public DbSet<Topping> Toppings { get; set; }

        public DbSet<NotificationSubscription> NotificationSubscriptions { get; set; }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring a many-to-many special -> topping relationship that is friendly for serialization
            modelBuilder.Entity<PizzaTopping>().HasKey(pst => new { pst.PizzaId, pst.ToppingId });
            modelBuilder.Entity<PizzaTopping>().HasOne<Pizza>().WithMany(ps => ps.Toppings);
            modelBuilder.Entity<PizzaTopping>().HasOne(pst => pst.Topping).WithMany();

            // Inline the Lat-Long pairs in Order rather than having a FK to another table
        }
    }
}