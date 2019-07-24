
namespace RepositoryAsyncCaching.ThirdPartyRepository
{
   // Cannot be modified
   internal interface IRepository<T>
   {
      T Get(string key);
   }
}