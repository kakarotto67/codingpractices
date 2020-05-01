using System;
using System.Collections.Generic;
using System.Linq;
using GCBL.DataAccess.Repositories.Abstract;
using GCBL.Shared.Helpers;

namespace GCBL.DataAccess.Repositories
{
    public class UserAccountsRepository : IRepository<UserAccounts>
    {
        public IEnumerable<UserAccounts> GetAll()
        {
            using (var context = new GcblPrincipalDatabase())
            {
                return context.UserAccounts;
            }
        }

        public UserAccounts GetEntityById(long entityId)
        {
            using (var context = new GcblPrincipalDatabase())
            {
                return context.UserAccounts.FirstOrDefault(entity => entity.UserId == entityId);
            }
        }

        public UserAccounts GetEntityByName(string name)
        {
            using (var context = new GcblPrincipalDatabase())
            {
                return context.UserAccounts.FirstOrDefault(entity =>
                    entity.UserName.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public UserAccounts GetEntityByCredentials(string name, string password)
        {
            using (var context = new GcblPrincipalDatabase())
            {
                var foundUser = context.UserAccounts.FirstOrDefault(entity =>
                    entity.UserName.Equals(name, StringComparison.InvariantCultureIgnoreCase));
                if (foundUser != null &&
                    StringEncryptionHelper.Decrypt(foundUser.Password)
                        .Equals(password, StringComparison.InvariantCulture))
                {
                    return foundUser;
                }

                return null;
            }
        }

        public bool TrySaveEntity(UserAccounts entity)
        {
            using (var context = new GcblPrincipalDatabase())
            {
                context.UserAccounts.Add(entity);
                try
                {
                    return context.SaveChanges() > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool TryUpdateEntity(UserAccounts entity)
        {
            throw new NotImplementedException();
        }

        public bool TryDeleteEntity(UserAccounts entity)
        {
            throw new NotImplementedException();
        }
    }
}
