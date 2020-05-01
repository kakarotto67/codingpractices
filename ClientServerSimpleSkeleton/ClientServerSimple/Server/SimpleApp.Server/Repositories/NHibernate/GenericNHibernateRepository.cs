using System.Collections.Generic;
using NHibernate;
using SimpleApp.Server.Repositories.NHibernate.UnitOfWork;

namespace SimpleApp.Server.Repositories.NHibernate
{
  public abstract class GenericNHibernateRepository<T> where T : class
  {
    protected readonly NHibernateUnitOfWork UnitOfWork;

    protected ISession Session
    {
      get { return UnitOfWork.Session; }
    }

    protected GenericNHibernateRepository(NHibernateUnitOfWork unitOfWork)
    {
      UnitOfWork = unitOfWork;
    }

    public virtual IList<T> GetAll()
    {
      return Session.QueryOver<T>().List();
    }
  }
}
