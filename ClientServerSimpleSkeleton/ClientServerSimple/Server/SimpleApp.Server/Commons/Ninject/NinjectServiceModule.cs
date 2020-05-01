using Ninject.Modules;
using SimpleApp.Server.Repositories.Interfaces;
using SimpleApp.Server.Repositories.NHibernate;
using SimpleApp.Server.Repositories.NHibernate.UnitOfWork;

namespace SimpleApp.Server.Commons.Ninject
{
  public class NinjectServiceModule : NinjectModule
  {
    public override void Load()
    {
      RegisterDependencies();
    }

    private void RegisterDependencies()
    {
      Bind<IUnitOfWork>().To<SharedNHibernateUnitOfWork>().InSingletonScope();
      Bind<IAppleRepository>().To<AppleRepository>().InSingletonScope();
      Bind<IWebService>().To<WebService>().InSingletonScope();
    }
  }
}
