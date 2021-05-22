// Decompiled with JetBrains decompiler
// Type: BlazingPizza.LatLong
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

namespace BlazingPizza
{
  public class LatLong
  {
    public LatLong()
    {
    }

    public LatLong(double latitude, double longitude)
      : this()
    {
      this.Latitude = latitude;
      this.Longitude = longitude;
    }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public static LatLong Interpolate(LatLong start, LatLong end, double proportion) => new LatLong(start.Latitude + (end.Latitude - start.Latitude) * proportion, start.Longitude + (end.Longitude - start.Longitude) * proportion);
  }
}
