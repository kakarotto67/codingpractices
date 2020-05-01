using System;
using System.Collections.Generic;

namespace GCBL.DataAccess.Repositories.Abstract
{
    public interface IReadOnlyRepository<out T>
        where T:class
    {
        IEnumerable<T> GetAll();
        T GetEntityById(Int64 entityId);
    }
}
