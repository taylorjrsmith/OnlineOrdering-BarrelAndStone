// Decompiled with JetBrains decompiler
// Type: BlazingPizza.DrinkOrderItem
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

using System;

namespace BlazingPizza
{
  public class DrinkOrderItem
  {
    public int Id { get; set; }

    public int OrderId { get; set; }

    public virtual Drink Drink { get; set; }

    public int DrinkId { get; set; }

    public Decimal Price => this.Drink.Price;

    public string GetFormattedPrice => this.Price.ToString("0.00");
  }
}
