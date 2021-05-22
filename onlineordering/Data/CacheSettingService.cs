using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKGroup.Settings;

namespace BlazorApp1.Data
{
    public class CacheSettingService :ISettingService
    {

        public SettingsService SettingsService { get; set; }
        public CacheHelper CacheHelper { get; set; }
        public CacheSettingService(SettingsService settingsService, CacheHelper cache)
        {
            SettingsService = settingsService;
            CacheHelper = cache;
        }

        public async Task AddSetting(Setting setting)
        {
            await SettingsService.AddSetting(setting);

        }

        public async Task UpdateSetting(Setting setting)
        {
            CacheHelper.ClearCache(setting.Key);
            await SettingsService.UpdateSetting(setting);
        }

        public async Task<T> GetSetting<T>(string settingKey, object defaultValue = null)
        {
            return CacheHelper.GetFromCache<T>(settingKey, () => SettingsService.GetSetting<T>(settingKey, defaultValue).Result);
        }
    }
}
