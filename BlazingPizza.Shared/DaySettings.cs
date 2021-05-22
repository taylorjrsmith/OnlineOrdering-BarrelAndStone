// Decompiled with JetBrains decompiler
// Type: BlazingPizza.DaySettings
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

using System;
using System.ComponentModel.DataAnnotations.Schema;
using TKGroup.InHouseOrder.Common.Organisation;

namespace BlazingPizza
{
  public class DaySettings
  {
    public Guid Id { get; set; }

    public string NameOfDay { get; set; }

    public bool AreOpen { get; set; }

    public string OpenHour { get; set; }

    public string ClosedHour { get; set; }

    public int Interval { get; set; }

    public int VenueId { get; set; }

    [ForeignKey("VenueId")]
    public virtual Venue Venue { get; set; }
  }
}
