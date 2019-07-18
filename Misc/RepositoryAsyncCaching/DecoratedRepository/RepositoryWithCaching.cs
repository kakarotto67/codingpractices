using RepositoryAsyncCaching.Caching;
using System;

namespace RepositoryAsyncCaching.DecoratedRepository
{
   public class RepositoryWithCaching : RepositoryDecorator
   {
      private readonly ICacheProvider<int> cacheProvider;
      private readonly object lockObject = new object();

      public RepositoryWithCaching(ICacheProvider<int> cacheProvider)
      {
         this.cacheProvider = cacheProvider;
      }

      // Decorated Get with caching logic
      public override int Get(string key)
      {
         lock (lockObject)
         {
            var cached = cacheProvider.Get(key);

            if (cached != Int32.MinValue)
            {
               Console.WriteLine("Cached value returned");
               return cached;
            }

            var result = base.Get(key);

            Console.WriteLine("Value saved into cache");
            cacheProvider.Set(key, result);

            return result;
         }
      }
   }
}