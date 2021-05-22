// Decompiled with JetBrains decompiler
// Type: BlazingPizza.OrderWithStatus
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

using BlazingPizza.ComponentsLibrary.Map;
using System;
using System.Collections.Generic;

namespace BlazingPizza
{
  public class OrderWithStatus
  {
    public static readonly TimeSpan PreparationDuration = TimeSpan.FromSeconds(10.0);
    public static readonly TimeSpan DeliveryDuration = TimeSpan.FromMinutes(1.0);

    public Order Order { get; set; }

    public string StatusText { get; set; }

    public List<Marker> MapMarkers { get; set; }

    public static OrderWithStatus FromOrder(Order order)
    {
      order.CreatedTime.Add(OrderWithStatus.PreparationDuration);
      string str = "Order Confirmed";
      return new OrderWithStatus()
      {
        Order = order,
        StatusText = str
      };
    }

    private static Marker ToMapMarker(string description, LatLong coords, bool showPopup = false) => new Marker()
    {
      Description = description,
      X = coords.Longitude,
      Y = coords.Latitude,
      ShowPopup = showPopup
    };
  }
}
