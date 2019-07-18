
namespace RepositoryAsyncCaching.Caching
{
   public interface ICacheProvider<T>
   {
      T Get(string key);
      void Set(string key, T value);
   }
}