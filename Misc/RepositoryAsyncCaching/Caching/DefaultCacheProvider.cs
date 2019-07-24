using System;
using System.Collections.Generic;

namespace RepositoryAsyncCaching.Caching
{
   internal class DefaultCacheProvider : ICacheProvider<int>
   {
      private Dictionary<string, int> cacheStorage = new Dictionary<string, int>();

      public int Get(string key)
      {
         if (cacheStorage.TryGetValue(key, out var valueFromCache))
         {
            return valueFromCache;
         }

         return Int32.MinValue;
      }

      public void Set(string key, int value)
      {
         if (cacheStorage.ContainsKey(key))
         {
            cacheStorage[key] = value;
         }
         else
         {
            cacheStorage.Add(key, value);
         }
      }
   }
}