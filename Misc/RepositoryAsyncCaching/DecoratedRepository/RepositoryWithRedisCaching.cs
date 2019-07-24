using Microsoft.Extensions.Caching.Distributed;
using System;

namespace RepositoryAsyncCaching.DecoratedRepository
{
   internal class RepositoryWithRedisCaching : RepositoryDecorator
   {
      private readonly IDistributedCache redisCache;
      private readonly object lockObject = new object();

      public RepositoryWithRedisCaching(IDistributedCache redisCache)
      {
         this.redisCache = redisCache;
      }

      // Decorated Get with caching logic
      public override int Get(string key)
      {
         lock (lockObject)
         {
            var cached = redisCache.GetString(key);

            if (!String.IsNullOrEmpty(cached) && Int32.TryParse(cached, out var cachedResult))
            {
               Console.WriteLine("Cached value returned");
               return cachedResult;
            }

            var result = base.Get(key);

            Console.WriteLine("Value saved into cache");
            redisCache.SetString(key, result.ToString(), new DistributedCacheEntryOptions
            {
               AbsoluteExpirationRelativeToNow = new TimeSpan(0, 1, 0)
            });

            return result;
         }
      }
   }
}