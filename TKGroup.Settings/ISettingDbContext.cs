﻿// Decompiled with JetBrains decompiler
// Type: TKGroup.Settings.ISettingDbContext
// Assembly: TKGroup.Settings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 79403CED-C884-4CB1-AB39-2C4088B9D379
// Assembly location: C:\Users\Taylor\Downloads\wwwroot (1)\TKGroup.Settings.dll

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TKGroup.Settings
{
  public interface ISettingDbContext
  {
    DbSet<Setting> Settings { get; set; }

    Task SaveChangesAsync();
  }
}
