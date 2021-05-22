// Decompiled with JetBrains decompiler
// Type: BlazingPizza.Order
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BlazingPizza
{
  public class Order
  {
    public int OrderId { get; set; }

    public string UserId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [RegularExpression("^(\\+44\\s?7\\d{3}|\\(?07\\d{3}\\)?)\\s?\\d{3}\\s?\\d{3}$", ErrorMessage = "Please enter a valid mobile number")]
    public string Number { get; set; }

    public string Password { get; set; } = Guid.NewGuid().ToString();

    public string Comment { get; set; }

    public DateTime CreatedTime { get; set; }

    public virtual List<Pizza> Pizzas { get; set; } = new List<Pizza>();

    public virtual List<DrinkOrderItem> Drinks { get; set; } = new List<DrinkOrderItem>();

    [BlazingPizza.CollectionDate]
    public DateTime CollectionDate { get; set; }

    public Decimal GetTotalPrice() => this.Pizzas.Sum<Pizza>((Func<Pizza, Decimal>) (p => p.GetTotalPrice())) + this.Drinks.Sum<DrinkOrderItem>((Func<DrinkOrderItem, Decimal>) (d => d.Price));

    public string GetFormattedTotalPrice() => this.GetTotalPrice().ToString("0.00");

    public string Status { get; set; } = "Ordered";
  }
}
