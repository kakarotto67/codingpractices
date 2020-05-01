using NHibernate;

namespace SimpleApp.Server.Repositories.NHibernate.UnitOfWork
{
  public class SharedNHibernateUnitOfWork : NHibernateUnitOfWork
  {
    /// <summary>
    /// Get current Session.
    /// </summary>
    public override ISession Session
    {
      get { return NHibernateConfiguration.SessionFactory.GetCurrentSession(); }
    }

    /// <summary>
    /// Save changes.
    /// </summary>
    public override void SaveChanges()
    {
      NHibernateConfiguration.SessionFactory.GetCurrentSession().Flush();
    }

    /// <summary>
    /// Clear changes.
    /// </summary>
    public override void ClearChanges()
    {
      NHibernateConfiguration.SessionFactory.GetCurrentSession().Clear();
    }

    public override void Dispose()
    {
      // The session is closed and disposed else where
    }
  }
}
