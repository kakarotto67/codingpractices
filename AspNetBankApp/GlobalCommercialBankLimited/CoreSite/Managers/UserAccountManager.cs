using GCBL.DataAccess;
using GCBL.DataAccess.Repositories;
using GCBL.DataAccess.Repositories.Abstract;

namespace GCBL.CoreSite.Managers
{
    internal class UserAccountManager
    {
        private readonly IRepository<UserAccounts> userAccountsRepository;

        public UserAccountManager()
        {
            userAccountsRepository = new UserAccountsRepository();
        }

        public bool RegisterNewUserAccount(string name, string password)
        {
            return userAccountsRepository.TrySaveEntity(
                new UserAccounts
                {
                    UserName = name,
                    Password = password
                });
        }

        public bool CheckIfUserValid(string name, string password)
        {
            return userAccountsRepository.GetEntityByCredentials(name, password) != null;
        }

        public bool CheckIfUserExists(string name)
        {
            return userAccountsRepository.GetEntityByName(name) != null;
        }
    }
}