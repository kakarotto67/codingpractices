using Microsoft.Practices.Unity;
using SimpleApp.Client.Client;
using SimpleApp.Client.Commons.Rest;
using SimpleApp.Client.Domain.Mappings;
using SimpleApp.Client.Domain.Model;
using SimpleApp.Client.Domain.ServiceAgents;
using SimpleApp.Client.Domain.ServiceAgents.Abstract;
using SimpleApp.Client.ServiceModel;

namespace SimpleApp.Client.Commons.IoC
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
      RegisterServices();
      RegisterMappings();
      RegisterProviders();
    }

    private void RegisterServices()
    {
      container.RegisterType<ISimpleAppServiceClient, SimpleAppServiceClient>();
      container.RegisterType<IAppleServiceAgent, AppleServiceAgent>();
    }

    private void RegisterMappings()
    {
      container.RegisterType<IMapping<AppleDto, Apple>, AppleMapping>();
    }

    private void RegisterProviders()
    {
      container.RegisterType<IApplesProvider, ApplesProvider>();
    }
  }
}
