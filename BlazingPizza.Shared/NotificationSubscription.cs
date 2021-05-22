// Decompiled with JetBrains decompiler
// Type: BlazingPizza.NotificationSubscription
// Assembly: BlazingPizza.Shared, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828454DF-6818-4B53-832D-B72D96F2EA56
// Assembly location: C:\Users\Taylor\Downloads\BlazingPizza.Shared.dll

namespace BlazingPizza
{
  public class NotificationSubscription
  {
    public int NotificationSubscriptionId { get; set; }

    public string UserId { get; set; }

    public string Url { get; set; }

    public string P256dh { get; set; }

    public string Auth { get; set; }
  }
}
