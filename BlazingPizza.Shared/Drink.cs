// Decompiled with JetBrains decompiler
// Type: BlazingPizza.Drink
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

using System;

namespace BlazingPizza
{
  public class Drink
  {
    public int Id { get; set; }

    public string DrinkName { get; set; }

    public Decimal Price { get; set; }

    public string ImageUrl { get; set; }

    public string ReportingCategory { get; set; }

    public string GetFormattedPrice => this.Price.ToString("0.00");
  }
}
