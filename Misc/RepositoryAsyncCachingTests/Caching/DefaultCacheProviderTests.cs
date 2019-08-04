using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryAsyncCaching.Caching;

namespace RepositoryAsyncCachingTests.Caching
{
   [TestClass]
   public class DefaultCacheProviderTests
   {
      private readonly DefaultCacheProvider defaultCacheProvider;
      private readonly Int32 defaultGetResult = Int32.MinValue;

      public DefaultCacheProviderTests()
      {
         defaultCacheProvider = new DefaultCacheProvider();
      }

      [TestMethod]
      public void IsCacheProviderInitialized()
      {
         Assert.IsNotNull(defaultCacheProvider);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentNullException))]
      public void GetThrowsExceptionIfKeyNull()
      {
         var result = defaultCacheProvider.Get(null);
      }

      [DataTestMethod]
      [DataRow("")]
      [DataRow("invalid")]
      public void GetReturnsDefaultIfKeyNotFound(string key)
      {
         var result = defaultCacheProvider.Get(key);
         Assert.AreEqual(result, defaultGetResult);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentNullException))]
      public void SetThrowsExceptionIfKeyNull()
      {
         defaultCacheProvider.Set(null, 0);
      }

      [TestMethod]
      public void SetAddsDataSuccessfully()
      {
         defaultCacheProvider.Set("", 0);
         defaultCacheProvider.Set("key1", 1);

         // Size must be 2 since 2 items are added
         Assert.AreEqual(defaultCacheProvider.CacheSize, 2);

         // Keys must return expected values
         Assert.AreEqual(defaultCacheProvider.Get(""), 0);
         Assert.AreEqual(defaultCacheProvider.Get("key1"), 1);
      }

      [TestMethod]
      public void SetUpdatesDataSuccessfully()
      {
         defaultCacheProvider.Set("", 2);
         defaultCacheProvider.Set("key1", 3);

         // Size must stay 2 since 2 items with same keys must be updated
         Assert.AreEqual(defaultCacheProvider.CacheSize, 2);

         // Keys must return updated values
         Assert.AreEqual(defaultCacheProvider.Get(""), 2);
         Assert.AreEqual(defaultCacheProvider.Get("key1"), 3);
      }
   }
}