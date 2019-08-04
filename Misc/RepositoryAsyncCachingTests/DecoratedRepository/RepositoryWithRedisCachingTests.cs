using Microsoft.Extensions.Caching.Distributed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepositoryAsyncCaching.DecoratedRepository;
using RepositoryAsyncCaching.ThirdPartyRepository;
using System;
using System.Collections.Generic;

namespace RepositoryAsyncCachingTests.DecoratedRepository
{
   [TestClass]
   public class RepositoryWithRedisCachingTests
   {
      private readonly RepositoryWithRedisCaching repositoryWithCaching;
      private Dictionary<String, Int32> keysFromCacheStub = new Dictionary<String, Int32>();
      private readonly Int32 defaultReturnResult = -1;

      public RepositoryWithRedisCachingTests()
      {
         var redisCacheMock = GetRedisCacheMock();
         repositoryWithCaching = new RepositoryWithRedisCaching(redisCacheMock.Object);
         repositoryWithCaching.SetRepository(new ExistingRepository());
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentNullException))]
      public void GetShouldThrowExceptionWhenNullIsPassed()
      {
         repositoryWithCaching.Get(null);
      }

      [TestMethod]
      public void GetShouldReturnDefaultResultWhenEmptyIsPassed()
      {
         var result = repositoryWithCaching.Get(String.Empty);
         Assert.AreEqual(result, defaultReturnResult);
      }

      [Ignore]
      private Mock<IDistributedCache> GetRedisCacheMock()
      {
         // Initialize mock
         var redisCacheMock = new Mock<IDistributedCache>();

         // Setup mock behavior to simulate real scenarios

         // Setup GetString method
         // Set up few cases for GetString method (when key is requested - return specified value)
         //foreach (var cachedItem in keysFromCacheStub)
         //{
         //   redisCacheMock.Setup(_this => _this.GetString(cachedItem.Key))
         //      .Returns(cachedItem.Value);
         //}

         redisCacheMock.Setup(mock => mock.GetString(It.IsAny<String>()))
               .Returns((string key) =>
               {
                  if (String.IsNullOrEmpty(key))
                  {
                     throw new ArgumentNullException();
                  }

                  if (keysFromCacheStub.ContainsKey(key))
                  {
                     return keysFromCacheStub[key].ToString();
                  }
                  else
                  {
                     return null;
                  }
               });

         redisCacheMock.Setup(_this => _this.GetString(It.IsNotIn<String>(null, String.Empty)))
               .Returns((string key) =>
               {
                  if (keysFromCacheStub.ContainsKey(key))
                  {
                     return keysFromCacheStub[key].ToString();
                  }
                  else
                  {
                     return null;
                  }
               });

         // Set up null and empty arguments cases
         redisCacheMock.Setup(_this => _this.GetString(String.Empty))
            .Returns(String.Empty);

         redisCacheMock.Setup(_this => _this.GetString(null))
            .Throws(new ArgumentNullException());

         // If any other strings passed - return null
         //redisCacheMock.Setup(_this => _this.GetString(It.IsNotIn<String>(keysFromCacheStub.Keys)))
         //   .Returns<String>(null);

         // Setup SetString method
         redisCacheMock.Setup(_this => _this.SetString(It.IsIn<String>(null, String.Empty), It.IsNotIn<String>(null, String.Empty)))
            .Throws(new ArgumentNullException());

         // Whenever SetString with valid key/value pair is called - add it to the dictionary
         redisCacheMock.Setup(_this => _this.SetString(It.IsNotIn<String>(null, String.Empty), It.IsAny<String>()))
           .Callback((string key, string value) =>
           {
              if (keysFromCacheStub.ContainsKey(key))
              {
                 throw new ArgumentException();
              }
              else
              {
                 keysFromCacheStub.Add(key, int.Parse(value));
              }
           });

         return redisCacheMock;
      }
   }
}