using System;

namespace SimpleApp.Server.Repositories.NHibernate.UnitOfWork
{
  public interface IUnitOfWork : IDisposable
  {
    void SaveChanges();
    void ClearChanges();
  }
}
