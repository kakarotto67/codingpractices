using System.ComponentModel.Composition;
using HomeWork.TL.Core.Common.Composition;
using HomeWork.TL.Infrastructure.Common.IoC;
using Microsoft.Practices.Unity;

namespace HomeWork.TL.Infrastructure
{
    [Export(typeof(IModule))]
    public class InfrastructureModule : IModule
    {
        private DependencyInjectionConfiguration dependencyInjectionConfiguration;

        public void Initialize(IUnityContainer container)
        {
            dependencyInjectionConfiguration = new DependencyInjectionConfiguration(container);
            dependencyInjectionConfiguration.Configure();
        }
    }
}
