// Decompiled with JetBrains decompiler
// Type: BlazingPizza.SpecialEventCategory
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

using System;

namespace BlazingPizza
{
  public class SpecialEventCategory
  {
    public Guid Id { get; set; }

    public DateTime EventDate { get; set; }

    public string StartTime { get; set; }

    public string EndTime { get; set; }

    public DateTime PreorderByDate { get; set; }

    public int FreeDeliveryThreshold { get; set; }

    public int TimeslotInterval { get; set; }

    public string LimitedPostcodePrepends { get; set; }

    public string[] LimitedPostcodes => this.LimitedPostcodePrepends?.Split(",");

    public string CategoryName { get; set; }
  }
}
