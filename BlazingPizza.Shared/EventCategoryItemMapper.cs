// Decompiled with JetBrains decompiler
// Type: BlazingPizza.EventCategoryItemMapper
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazingPizza
{
  public class EventCategoryItemMapper
  {
    public Guid ID { get; set; }

    public Guid EventId { get; set; }

    [ForeignKey("EventId")]
    public SpecialEventCategory SpecialEventCategory { get; set; }

    public int SpecialId { get; set; }

    [ForeignKey("SpecialId")]
    public PizzaSpecial PizzaSpecials { get; set; }
  }
}
