// Decompiled with JetBrains decompiler
// Type: BlazingPizza.KitchenInfo
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

using System;
using System.Collections.Generic;

namespace BlazingPizza
{
  public class KitchenInfo
  {
    public Decimal TotalIncome { get; set; }

    public Dictionary<string, int> TodaysSales { get; set; }

    public Dictionary<string, int> Drinks { get; set; }

    public int TotalPizzas { get; set; }

    public int EightInch { get; set; }

    public int TwelveInch { get; set; }

    public int GlutenFree { get; set; }
  }
}
