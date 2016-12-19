using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace WebApiCacheDemo.Mvc.Caching
{
    public class InMemoryCache : ICacheService
    {
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            return GetOrSet(cacheKey, getItemCallback, 30);
        }

        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, int minutes) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item == null)
            {
                item = getItemCallback();
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(minutes));
            }
            return item;
        }
    }

    public interface ICacheService
    {
        T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class;
        T GetOrSet<T>(string cacheKey, Func<T> getItemCallback, int minutes) where T : class;
    }
}