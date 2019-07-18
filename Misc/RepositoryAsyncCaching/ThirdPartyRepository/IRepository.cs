
namespace RepositoryAsyncCaching.ThirdPartyRepository
{
   // Cannot be modified
   public interface IRepository<T>
   {
      T Get(string key);
   }
}