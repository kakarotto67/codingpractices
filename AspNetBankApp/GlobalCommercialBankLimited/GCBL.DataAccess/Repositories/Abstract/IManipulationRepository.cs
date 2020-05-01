namespace GCBL.DataAccess.Repositories.Abstract
{
    public interface IManipulationRepository<in T>
        where T : class
    {
        bool TrySaveEntity(T entity);
        bool TryUpdateEntity(T entity);
        bool TryDeleteEntity(T entity);
    }
}
