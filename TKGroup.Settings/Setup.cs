// Decompiled with JetBrains decompiler
// Type: TKGroup.Settings.Setup
// Assembly: TKGroup.Settings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 79403CED-C884-4CB1-AB39-2C4088B9D379
// Assembly location: C:\Users\Taylor\Downloads\wwwroot (1)\TKGroup.Settings.dll

using Microsoft.Extensions.DependencyInjection;

namespace TKGroup.Settings
{
  public static class Setup
  {
    public static void AddTKGroupSettings(this IServiceCollection services) => services.AddScoped<SettingsService>();
  }
}
