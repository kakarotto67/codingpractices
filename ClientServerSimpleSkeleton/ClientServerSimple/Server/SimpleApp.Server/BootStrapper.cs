using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.Web.Routing;
using SimpleApp.Server.Commons.Ioc;
using SimpleApp.Server.Commons.WCF.NHibernate;
using SimpleApp.Server.Commons.WCF.Unity;
using SimpleApp.Server.Repositories.NHibernate;

namespace SimpleApp.Server
{
  public class BootStrapper
  {
    private DependencyInjectionConfiguration dependencyInjectionConfiguration;

    public void Initialize()
    {
      InitializeDependencyInjection();
      InitializeNHibernate();
      StartWebService();
    }

    private static void InitializeNHibernate()
    {
      NHibernateConfiguration.Initialize();
    }

    private void InitializeDependencyInjection()
    {
      dependencyInjectionConfiguration = new DependencyInjectionConfiguration(DependencyInjection.Container);
      dependencyInjectionConfiguration.Configure();
    }

    private static void StartWebService()
    {
      var webServiceHostFactory = new UnityWebServiceHostFactory(CreateServiceBehaviors());
      RouteTable.Routes.Add(new ServiceRoute("Api",
                                             webServiceHostFactory,
                                             typeof (WebService)));
    }

    private static ICollection<IServiceBehavior> CreateServiceBehaviors()
    {
      ICollection<IServiceBehavior> serviceBehaviors = new Collection<IServiceBehavior>();
      serviceBehaviors.Add(new UnityServiceBehavior());
      serviceBehaviors.Add(new NHibernateUnitOfWorkServiceBehavior());
      return serviceBehaviors;
    }
  }
}
