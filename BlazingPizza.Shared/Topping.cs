// Decompiled with JetBrains decompiler
// Type: BlazingPizza.Topping
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

using System;

namespace BlazingPizza
{
  public class Topping
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public Decimal Price { get; set; }
    public bool IsDeleted { get; set; }

    public string GetFormattedPrice(int size) => size != 8 ? this.Price.ToString("0.00") : (this.Price / 2M).ToString("0.00");
  }
}
