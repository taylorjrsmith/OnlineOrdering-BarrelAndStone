// Decompiled with JetBrains decompiler
// Type: BlazingPizza.DefaultMenu
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

using System;

namespace BlazingPizza
{
  public class DefaultMenu
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string ImageUrl { get; set; }

    public string Description { get; set; }

    public Decimal DefaultBasePrice { get; set; }

    public Decimal DefaultTwelveInchPrice { get; set; }

    public bool IsSide { get; set; }

    public bool CanBeVegan { get; set; }

    public string GetFormattedBasePrice() => this.DefaultBasePrice.ToString("0.00");
  }
}
