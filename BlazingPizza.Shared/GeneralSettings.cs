// Decompiled with JetBrains decompiler
// Type: BlazingPizza.GeneralSettings
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

namespace BlazingPizza
{
  public class GeneralSettings
  {
    public int Id { get; set; }

    public double PizzaBlockingInterval { get; set; }

    public int MaxNumberOfPizzasToBlockNext { get; set; }

    public int MaxNumberOfPizzasToAllowSecondOrder { get; set; }

    public int NumberOfPizzasAllowedInSecondOrder { get; set; }

    public bool GlutenFreeInStock { get; set; }

    public bool AcceptingOrders { get; set; }
  }
}
