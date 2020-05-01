namespace GCBL.DataAccess.Repositories.Abstract
{
    public interface IAuthenticityRepository<out T>
        where T:class
    {
        T GetEntityByName(string name);
        T GetEntityByCredentials(string name, string password);
    }
}
