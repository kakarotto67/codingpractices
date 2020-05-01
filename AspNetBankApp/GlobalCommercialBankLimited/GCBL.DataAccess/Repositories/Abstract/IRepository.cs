namespace GCBL.DataAccess.Repositories.Abstract
{
    public interface IRepository<T> : IReadOnlyRepository<T>, IManipulationRepository<T>, IAuthenticityRepository<T>
        where T:class
    {
    }
}
