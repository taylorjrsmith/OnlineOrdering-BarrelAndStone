// Decompiled with JetBrains decompiler
// Type: BlazingPizza.Pizza
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BlazingPizza
{
  public class Pizza
  {
    public const int DefaultSize = 8;
    public const int MinimumSize = 8;
    public const int MaximumSize = 12;

    public int Id { get; set; }

    public int OrderId { get; set; }

    [ForeignKey("SpecialId")]
    public virtual PizzaSpecial Special { get; set; }

    public int SpecialId { get; set; }

    public int Size { get; set; }

    public bool GlutenFree { get; set; }

    public bool Vegan { get; set; }

    public bool IsSide => this.Special.IsSide;

    public bool IsRestricted => this.Special.RestrictedItem;

    public virtual List<PizzaTopping> Toppings { get; set; }

    public Decimal GetBasePrice() => this.Size != 8 ? this.Special.TwelveInchPrice : this.Special.EightInchPrice;

    public Decimal GetTotalPrice()
    {
      Decimal num = this.Size == 8 ? this.Toppings.Sum<PizzaTopping>((Func<PizzaTopping, Decimal>) (t => t.Topping.Price)) / 2M : this.Toppings.Sum<PizzaTopping>((Func<PizzaTopping, Decimal>) (t => t.Topping.Price));
      return this.GetBasePrice() + num + (Decimal) (this.GlutenFree ? 1 : 0);
    }

    public string GetFormattedTotalPrice() => this.GetTotalPrice().ToString("0.00");
  }
}
