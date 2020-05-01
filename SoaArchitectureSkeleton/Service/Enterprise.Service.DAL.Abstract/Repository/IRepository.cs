using System;

namespace Enterprise.Service.DAL.Shared.Repository
{
    public interface IRepository<T>
        where T : class
    {
        T GetEntityById(Int32 id);
    }
}
