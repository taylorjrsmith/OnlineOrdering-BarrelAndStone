// Decompiled with JetBrains decompiler
// Type: TKGroup.Settings.SettingsService
// Assembly: TKGroup.Settings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 79403CED-C884-4CB1-AB39-2C4088B9D379
// Assembly location: C:\Users\Taylor\Downloads\wwwroot (1)\TKGroup.Settings.dll

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TKGroup.Settings
{
  public class SettingsService : ISettingService
  {
    public ISettingDbContext _db { get; set; }

    public SettingsService(ISettingDbContext settingDbContext) => this._db = settingDbContext;

    public async Task AddSetting(Setting setting)
    {
      this._db.Settings.Add(setting);
      await this._db.SaveChangesAsync();
    }

    public async Task UpdateSetting(Setting setting)
    {
      this._db.Settings.Update(setting);
      await this._db.SaveChangesAsync();
    }

    public async Task<T> GetSetting<T>(string settingKey, object defaultValue = null)
    {
      Setting setting = await this._db.Settings.FirstOrDefaultAsync<Setting>((Expression<Func<Setting, bool>>) (a => a.Key == settingKey));
      return setting != null ? (T) Convert.ChangeType((object) setting.Value, typeof (T)) : (T) defaultValue;
    }

    public async Task<List<Setting>> GetAllSettings() => await this._db.Settings.ToListAsync<Setting>();
  }
}
