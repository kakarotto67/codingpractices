using System;

namespace RepositoryAsyncCaching.ThirdPartyRepository
{
   // Cannot be modified
   public class ExistingRepository : IRepository<int>
   {
      public int Get(string key)
      {
         Console.WriteLine("Value returned from repository");

         if (Int32.TryParse(key, out var result))
         {
            return result;
         }

         return -1;
      }
   }
}