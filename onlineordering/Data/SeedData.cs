using BlazingPizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public static class SeedData
    {
        public static void Initialize(PizzaStoreContext db)
        {
            var toppings = new Topping[]
            {
                new Topping()
                {
                    Name = "3 Slices Italian Napoli salami",
                    Price = 1.50m,
                },
                new Topping()
                {
                    Name = "Speck ham",
                    Price = 1.50m,
                },
                new Topping()
                {
                    Name = "Fennel sausage",
                    Price = 1.50m,
                },
                new Topping()
                {
                    Name = "Chorizo",
                    Price = 1.50m,
                },
                new Topping()
                {
                    Name = "Parma ham",
                    Price = 1.50m
                },
                new Topping()
                {
                    Name = "Seared chicken breast",
                    Price = 2.00m,
                },
                new Topping()
                {
                    Name = "Spicy Calabrian Nduja sausage",
                    Price = 1.50m,
                },
                new Topping()
                {
                    Name = "Spicy Ventrica Salami",
                    Price = 1.50m,
                },
                new Topping()
                {
                    Name = "Sweet peppadew peppers",
                    Price = 1.00m,
                },
                new Topping()
                {
                    Name = "Chili rings",
                    Price = 1.00m,
                },
                new Topping()
                {
                    Name = "Mushrooms",
                    Price = 1.00m,
                },
                new Topping()
                {
                    Name = "Fillet peppers",
                    Price = 1.00m,
                },
                new Topping()
                {
                    Name = "Rocket",
                    Price = 0.75m,
                },
                new Topping()
                {
                    Name = "Lobster on top",
                    Price = 64.50m,
                },
                new Topping()
                {
                    Name = "Served on a silver platter",
                    Price = 25.00m,
                },
                new Topping()
                {
                    Name = "Courgettes",
                    Price = 1.00m,
                },
                new Topping()
                {
                    Name = "Red onions",
                    Price = 1.00m,
                },
                new Topping()
                {
                    Name = "Balsamic Glaze",
                    Price = 0.50m,
                },
                new Topping()
                {
                    Name = "Parmesan",
                    Price = 0.75m,
                }
            };

            var specials = new PizzaSpecial[]
            {
                new PizzaSpecial()
                {
                    Name = "Rustic Classic",
                    Description = "Barrel & Stone tomato sauce and creamy Fior di latte mozarella",
                    BasePrice = 5.50m,
                    EightInchPrice = 5.75m,
                    TwelveInchPrice = 8.75m,
                    ImageUrl = "img/barrel-and-stone/rustic-classic-min.jpg",
                    CanBeVegan = true,
                },
                new PizzaSpecial()
                {
                    Id = 2,
                    Name = "Simply Salami",
                    Description = "Italian Napoli Salami, Barrel & Stone tomato sauce and Fior di latte mozarella",
                    BasePrice = 11.99m,
                    EightInchPrice = 6.50m,
                    TwelveInchPrice = 10.00m,
                    ImageUrl = "img/barrel-and-stone/simply-salami-min.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 3,
                    Name = "The Works",
                    Description = "Italian Napoli Salami, Smoked speck ham, black pepper and fennel sausage, Barrel and stone tomato sauce and Fior di latte mozarella",
                    EightInchPrice = 7.00m,
                    TwelveInchPrice = 11.50m,
                    ImageUrl = "img/barrel-and-stone/the-works-min.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 4,
                    Name = "Sweet & Tangy",
                    Description = "Barrel & Stone tomato sauce, Tangy goat's cheese, sweet peppadew peppers and pesto",
                    EightInchPrice = 6.50m,
                    TwelveInchPrice = 10.50m,
                    ImageUrl = "img/barrel-and-stone/sweet-n-tangy-min.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 5,
                    Name = "Nice & Spicy",
                    Description = "Spicy Calabrian Nduja sausage, Barrel & Stone tomato sauce, Fior di latte mozzarella, sweet peppadew peppers, fiery salami and chili peppers",
                    EightInchPrice = 6.50m,
                    TwelveInchPrice = 10.50m,
                    ImageUrl = "img/barrel-and-stone/nice-n-spicy-min.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 6,
                    Name = "Gone Trufflin'",
                    Description = "Decadent mushroom and black truffle paste, smoky speck ham, mushrooms, Fior di latte mozzarella",
                    EightInchPrice = 6.50m,
                    TwelveInchPrice = 10.50m,
                    ImageUrl = "img/barrel-and-stone/gone-trufflin-min.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 7,
                    Name = "The Spaniard",
                    Description = "Chorizo seasoned with paprika, herbs and garlic, Pecorino sheep cheese, Barrel & Stone tomato sauce, fillet peppers, Grana Padano Parmesan and sprinkles of oregano",
                    EightInchPrice = 6.75m,
                    TwelveInchPrice = 11.00m,
                    ImageUrl = "img/barrel-and-stone/the-spaniard-min.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 8,
                    Name = "Rock The Parma",
                    Description = "Barrel & Stone tomato sauce, Fior di latte mozarella, wild rocket, Parmigiano Reggiano and parma ham, topped with a dash of balsamic glaze",
                    EightInchPrice = 6.50m,
                    TwelveInchPrice = 10.50m,
                    ImageUrl = "img/barrel-and-stone/rock-the-parma-min.jpg",
                },
                new PizzaSpecial()
                {
                    Id = 9,
                    Name = "Skinny Fries",
                    IsSide = true,
                    EightInchPrice = 2.00m,
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQrT6uE-WflbNGwfUNO5aouV-3z9e1aCKIX8JKz2HVVtVZpgji_&usqp=CAU"
                },
                new PizzaSpecial()
                {
                    Id = 10,
                    Name = "Chicken & Pesto",
                    Description = "A base of nutty green pesto stacked with crushed garlic, Fior di latte mozzarella, seared chicken breasts, capers and courgettes",
                    EightInchPrice = 7.00m,
                    TwelveInchPrice = 11.50m,
                    ImageUrl = "img/barrel-and-stone/deliveroo-chicken-and-pesto.jpg"
                },
                new PizzaSpecial()
                {
                    Id = 11,
                    Name = "The Garden Club (v, vg)",
                    Description = "Barrel & Stone tomato sauce, crushed garlic, Fior di latte mozzarella, sweet red onions, courgettes, peppadew peppers finished with wild rocket and balsamic glaze",
                    EightInchPrice = 6.75m,
                    TwelveInchPrice = 11.00m,
                    CanBeVegan = true,
                    ImageUrl = "img/barrel-and-stone/deliveroo-the-garden-club.jpg"
                },
                new PizzaSpecial()
                {
                    Id = 12,
                    Name = "Smoky Chilli Chicken",
                    Description = "A smoky paprika covered base, topped with Barrel & Stone tomato sauce, Fior di latte mozzarella, seared chicken breasts and finished with some cheeky red chilli's",
                    EightInchPrice = 7.00m,
                    TwelveInchPrice = 11.50m,
                    ImageUrl = "img/barrel-and-stone/deliveroo-smoky-chilli-chicken.jpg"
                },
                new PizzaSpecial()
                {
                    Id = 13,
                    Name = "Garlic bread",
                    Description = "Italian bread drizzled with garlic infused olive oil",
                    EightInchPrice = 3.50m,
                    IsSide = true,
                    ImageUrl = "img/barrel-and-stone/garlicbread.jpg"
                },
                new PizzaSpecial()
                {
                    Id = 14,
                    Name = "Garlic & Mozzarella",
                    Description = "Italian bread drizzled with garlic infused olive oil, topped with Fior di latte mozzarella and balsamic glaze",
                    EightInchPrice = 4.5m,
                    IsSide = true,
                    ImageUrl = "img/barrel-and-stone/garlic-mozz.png"
                },
                new PizzaSpecial()
                {
                    Id = 15,
                    Name = "Sweet potato fries",
                    EightInchPrice = 3.0m,
                    IsSide = true,
                    ImageUrl = "img/barrel-and-stone/sweet-potato.jpg"
                },
                new PizzaSpecial()
                {
                    Id = 16,
                    Name = "Chunky chips",
                    EightInchPrice = 2.0m,
                    IsSide = true,
                    ImageUrl = "img/barrel-and-stone/chunky-chips.jpg"
                },
                 new PizzaSpecial()
                 {
                     Id = 17,
                     Name = "Mozarella sticks",
                     EightInchPrice = 3.5m,
                     IsSide = true,
                     ImageUrl = "img/barrel-and-stone/mozzarella-sticks.jpg"
                 },
                 new PizzaSpecial()
                 {
                     Id = 18,
                     Name = "Breaded chicken goujons",
                     EightInchPrice = 3.5m,
                     IsSide = true,
                     ImageUrl = "img/barrel-and-stone/goujons.jpg"
                 },
                 new PizzaSpecial()
                 {
                     Id = 19,
                     Name = "Spicy chicken bites ",
                     EightInchPrice = 3.5m,
                     IsSide = true,
                     ImageUrl = "img/barrel-and-stone/spicy-chicken-bites.jpg"
                 }
            };

            var drinks = new Drink[]
            {
                new Drink
                {
                Id = 1,
                 DrinkName = "Kopparberg non alcoholic strawberry and lime",
                  ImageUrl = "https://imgix.bustle.com/uploads/image/2020/1/21/0c88a763-ecc7-49e2-af85-af507e2535bd-screen-shot-2020-01-21-at-15338-pm.png?w=646&fit=max&auto=format%2Ccompress&cs=srgb&q=70",
                   Price = 2.50M
                },
                new Drink
                {
                    Id = 2,
                    DrinkName = "Peroni large bottle",
                    ImageUrl = "img/drinks/peroni.jpg",
                    Price = 3.50m
                },
                new Drink
                {
                    Id = 3,
                    DrinkName = "Bulmers large bottle",
                    ImageUrl = "img/drinks/bulmers.jpg",
                    Price = 2.50m,
                },
                new Drink
                {
                    Id = 4,
                    DrinkName = "Diet Coke can",
                    ImageUrl = "img/drinks/dietcoke.jpg",
                    Price = 1.5m
                },
                new Drink
                {
                    Id = 5,
                    DrinkName = "Coca cola can",
                    ImageUrl = "img/drinks/coke.jpg",
                    Price = 1.5m
                },
                new Drink
                {
                    Id = 6,
                    DrinkName = "San Pellegrino Aranciata (orange)",
                    Price = 1.5m,
                    ImageUrl = "img/drinks/aranciata.jpg"
                },
                new Drink
                {
                    Id = 7,
                    DrinkName = "San Pellegrino Limonata (lemonade)",
                    ImageUrl = "img/drinks/limonata.jpg",
                    Price = 1.5m,
                },
                new Drink
                {
                    Id = 8,
                    DrinkName = "Fentimans rose lemonade",
                    ImageUrl = "img/drinks/fentimans-rose.jpg",
                    Price = 2.0m
                },
                new Drink
                {
                    Id = 9,
                    DrinkName = "Fentimans lemonade",
                    ImageUrl = "img/drinks/fentimans-lemon.jpg",
                    Price = 2.0m
                },
                new Drink
                {
                    Id = 10,
                    DrinkName = "Fentimans non-acoholic ginger beer",
                    ImageUrl = "img/drinks/fentimans-gb.jpg",
                    Price = 2.0m
                },
                new Drink
                {
                    Id = 11,
                    DrinkName = "Coke Zero bottle",
                    ImageUrl = "img/drinks/coke-zero.jpg",
                    Price = 1.50m
                },
                new Drink
                {
                    Id = 12,
                    DrinkName = "Prosecco single serve (187 ml)",
                    ImageUrl = "img/drinks/prosecco.jpg",
                    Price = 5.0m
                },
                new Drink
                {
                    Id = 13,
                    DrinkName = "Pinot Grigio",
                    ImageUrl = "img/drinks/pinotgrigio.jpg",
                    Price = 10.0m
                },
                new Drink
                {
                   Id = 23,
                   DrinkName = "Pinot Rose",
                    ImageUrl = "img/drinks/pinot-rose.jpeg",
                    Price = 10.0m
                },
                new Drink
                {
                    Id = 24,
                    DrinkName = "Malbec",
                    ImageUrl = "img/drinks/malbec.jpg",
                    Price = 12.0m
                },
                new Drink
                {
                    Id = 25,
                    DrinkName = "Budweiser",
                    ImageUrl = "img/drinks/budweiser.jpg",
                    Price = 2.50m
                },
                new Drink
                {
                    Id = 14,
                    DrinkName = "New Zealand Sauvignon blanc",
                    ImageUrl = "img/drinks/nz.jpg",
                    Price = 12.0m
                },
                new Drink
                {
                    Id = 15,
                    DrinkName = "Rioja rose",
                    ImageUrl = "img/drinks/rioja-rose.jpg",
                    Price = 10.0m
                },
                new Drink
                {
                    Id = 16,
                    DrinkName = "Rioja white",
                    ImageUrl = "img/drinks/rioja-white.jpg",
                    Price = 10.0m
                },
                new Drink
                {
                    Id = 17,
                    DrinkName = "Rioja red",
                    ImageUrl = "img/drinks/rioja-red.jpeg",
                    Price = 10.0m
                },
                new Drink
                {
                    Id = 18,
                    DrinkName = "Sugarbird white zinfadel",
                    ImageUrl = "img/drinks/sugarbird.jpg",
                    Price = 10.0m
                },
                //new Drink
                //{
                //    Id = 19,
                //    DrinkName = "Spain Sauvignon blanc",
                //    ImageUrl = "img/drinks/spain.jpg",
                //    Price = 10.0m
                //},
                new Drink
                {
                    Id = 20,
                    DrinkName = "Chile Sauvignon blanc",
                    ImageUrl = "img/drinks/chile.jpg",
                    Price = 10.0m,
                },
                new Drink
                {
                    Id = 21,
                    DrinkName = "South Australian Chardonnay",
                    ImageUrl = "img/drinks/australia.jpg",
                    Price = 10.0m
                },
                new Drink
                {
                    Id = 22,
                    DrinkName = "Australian shiraz",
                    ImageUrl = "img/drinks/australia.jpg",
                    Price = 10.0m
                }
            };

            db.Toppings.AddRange(toppings);
            db.SaveChanges();
            db.Specials.AddRange(specials);
            db.SaveChanges();
            db.Drinks.AddRange(drinks);
            db.SaveChanges();
        }
    }
}