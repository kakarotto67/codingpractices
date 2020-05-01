using Microsoft.Practices.Unity;
using SimpleApp.Server.Repositories.Interfaces;
using SimpleApp.Server.Repositories.NHibernate;
using SimpleApp.Server.Repositories.NHibernate.UnitOfWork;

namespace SimpleApp.Server.Commons.Ioc
{
  public class DependencyInjectionConfiguration
  {
    private readonly IUnityContainer container;

    public DependencyInjectionConfiguration(IUnityContainer container)
    {
      this.container = container;
    }

    public void Configure()
    {
      container.RegisterType<IUnitOfWork, SharedNHibernateUnitOfWork>();

      RegisterRepositories();
    }

    private void RegisterRepositories()
    {
      container.RegisterType<IAppleRepository, AppleRepository>();
    }
  }
}
