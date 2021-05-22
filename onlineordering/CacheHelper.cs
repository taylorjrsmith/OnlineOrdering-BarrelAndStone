using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1
{
    public class CacheHelper
    {
        IMemoryCache MemoryCache { get; set; }
        public CacheHelper(IMemoryCache cache)
        {
            MemoryCache = cache;
        }

        public T GetFromCache<T>(string cacheKey, Func<T> LoadObject, TimeSpan? cacheExpiration = null)
        {
            T cacheObject;
            cacheExpiration = cacheExpiration ?? new TimeSpan(1, 0, 0, 0, 0);
            MemoryCache.TryGetValue<T>(cacheKey, out cacheObject);
            if (cacheObject == null || (int.TryParse(cacheObject.ToString(), out int value) && value == 0) 
                || (bool.TryParse(cacheObject.ToString(), out bool boolval) && boolval == false))
            {
                cacheObject = LoadObject.Invoke();
                MemoryCache.Set(cacheKey, cacheObject, DateTime.Now.Add((TimeSpan)cacheExpiration)); 

            }
            return cacheObject;
        }

        public void ClearCache(string cacheKey)
        {
            MemoryCache.Remove(cacheKey);
        }

    }
}
