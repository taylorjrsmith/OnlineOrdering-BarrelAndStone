// Decompiled with JetBrains decompiler
// Type: BlazingPizza.PizzaSpecial
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

using System;

namespace BlazingPizza
{
  public class PizzaSpecial
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public Decimal BasePrice { get; set; }

    public Decimal EightInchPrice { get; set; }

    public Decimal TwelveInchPrice { get; set; }

    public int StockCount { get; set; } = 100;

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public bool CanBeVegan { get; set; }

    public bool CanBeTwelveInch { get; set; }

    public bool IsSide { get; set; }

    public bool RestrictedItem { get; set; }

    public bool IsEventItem { get; set; }

    public string GetFormattedBasePrice() => this.EightInchPrice.ToString("0.00");

    public bool IsEnabled { get; set; }

    public string Category { get; set; }
    public string TestField { get; set; }
  }
}
