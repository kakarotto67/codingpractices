using Microsoft.Extensions.DependencyInjection;
using RepositoryAsyncCaching.DecoratedRepository;
using RepositoryAsyncCaching.ThirdPartyRepository;
using System;
using System.Threading.Tasks;

namespace RepositoryAsyncCaching
{
   class Program
   {
      private static readonly ServiceCollection services = new ServiceCollection();

      static void Main()
      {
         ConfigureServices();

         var serviceProvider = services.BuildServiceProvider();
         var repo = serviceProvider.GetService<IRepository<int>>();
         ((RepositoryWithRedisCaching)repo).SetRepository(new ExistingRepository());

         // Not cached
         for (int i = -5; i <= 5; i++)
         {
            var result = repo.Get($"{i}");
            Console.WriteLine($"Result is: {result}");
         }

         Console.WriteLine($"\n----------------------------\n");

         // Cached
         for (int i = -5; i <= 5; i++)
         {
            var result = repo.Get($"{i}");
            Console.WriteLine($"Result is: {result}");
         }

         // Multithreading test
         for (int i = 0; i < 10; i++)
         {
            Task.Run(() =>
            {
               var result = repo.Get($"53");
               Console.WriteLine($"Result is: {result}");
            });
         }

         // Async test
         var asyncTest1Result = AsyncTest1().Result;
         var asyncTest2Result = AsyncTest2().Result;

         Console.WriteLine($"Async test 1 result: {asyncTest1Result} milliseconds");
         Console.WriteLine($"Async test 2 result: {asyncTest2Result} milliseconds");

         Console.ReadKey();
      }

      private static void ConfigureServices()
      {
         //services.AddSingleton<ICacheProvider<int>, DefaultCacheProvider>();
         services.AddSingleton<IRepository<int>, RepositoryWithRedisCaching>();

         // Setup Redis Cache
         //ConfigurationOptions config = new ConfigurationOptions
         //{
         //   EndPoints =
         //   {
         //      { "redis-master", 5155 }
         //   },
         //   KeepAlive = 180,
         //   DefaultVersion = new Version(2, 8, 8),
         //   Password = "changeme"
         //};

         // To be able to connect to redis server run its docker container first:
         // Docker command:
         // docker run --name redis-master -d -p 5155:6379 redis
         // Docker compose command:
         // docker-compose -f "docker-compose.yml" up
         services.AddDistributedRedisCache(options =>
         {
            options.Configuration = "127.0.0.1:5155";
            options.InstanceName = "redis-master";
            //options.ConfigurationOptions = config;
         });
      }

      /// <summary>
      /// This methods lasts ~4 seconds since we run delay task and await it and only then run
      /// second delay task and also await it (2 + 2 = 4)
      /// </summary>
      private static async Task<double> AsyncTest1()
      {
         var startTime = DateTime.UtcNow.Ticks;

         await Task.Delay(2000);
         await Task.Delay(2000);

         var endTime = DateTime.UtcNow.Ticks;

         return new TimeSpan(endTime - startTime).TotalMilliseconds;
      }

      /// <summary>
      /// This method lasts ~2 seconds since we run first delay task, then second delay task
      /// and since they are async tasks and we use awaiters later so they are executed in parallel,
      /// therefore result is 2 (2 with 2 at the same time gives 2)
      /// </summary>
      private static async Task<double> AsyncTest2()
      {
         var startTime = DateTime.UtcNow.Ticks;

         var task1 = Task.Delay(2000);
         var task2 = Task.Delay(2000);

         await task1;
         await task2;

         var endTime = DateTime.UtcNow.Ticks;

         return new TimeSpan(endTime - startTime).TotalMilliseconds;
      }
   }
}