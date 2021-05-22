// Decompiled with JetBrains decompiler
// Type: BlazingPizza.PizzaTopping
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

namespace BlazingPizza
{
  public class PizzaTopping
  {
    public virtual Topping Topping { get; set; }

    public int ToppingId { get; set; }

    public int PizzaId { get; set; }
  }
}
