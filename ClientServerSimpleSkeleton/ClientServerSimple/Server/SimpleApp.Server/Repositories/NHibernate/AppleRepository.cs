using SimpleApp.Server.Domain;
using SimpleApp.Server.Repositories.Interfaces;
using SimpleApp.Server.Repositories.NHibernate.UnitOfWork;

namespace SimpleApp.Server.Repositories.NHibernate
{
  public class AppleRepository : GenericNHibernateRepository<Apple>, IAppleRepository
  {
    public AppleRepository(IUnitOfWork unitOfWork)
      : base((NHibernateUnitOfWork) unitOfWork)
    {
    }
  }
}
