using NHibernate;

namespace SimpleApp.Server.Repositories.NHibernate.UnitOfWork
{
  public abstract class NHibernateUnitOfWork : IUnitOfWork
  {
    public abstract ISession Session { get; }

    public abstract void SaveChanges();
    public abstract void ClearChanges();
    public abstract void Dispose();
  }
}
