using HomeWork.TL.Core.Shared.Interfaces.InfrastructureModule.CrossCutting.Logging;
using HomeWork.TL.Infrastructure.CrossCutting.Logging;
using Microsoft.Practices.Unity;

namespace HomeWork.TL.Infrastructure.Common.IoC
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
            RegisterLogger();
        }

        private void RegisterLogger()
        {
            // Register SimpleLogger as a Singleton
            container.RegisterType<ILogger, SimpleLogger>(new ContainerControlledLifetimeManager());
        }
    }
}
