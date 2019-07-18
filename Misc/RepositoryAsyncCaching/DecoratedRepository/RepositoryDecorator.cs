using RepositoryAsyncCaching.ThirdPartyRepository;

namespace RepositoryAsyncCaching.DecoratedRepository
{
   public abstract class RepositoryDecorator : IRepository<int>
   {
      protected IRepository<int> repository;

      public void SetRepository(IRepository<int> repository)
      {
         this.repository = repository;
      }

      public virtual int Get(string key)
      {
         if (repository != null)
         {
            return repository.Get(key);
         }

         return -1;
      }
   }
}