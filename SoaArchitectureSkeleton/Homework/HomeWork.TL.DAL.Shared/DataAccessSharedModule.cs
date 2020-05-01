using System.ComponentModel.Composition;
using HomeWork.TL.Core.Common.Composition;
using HomeWork.TL.DAL.Shared.Common.IoC;
using Microsoft.Practices.Unity;

namespace HomeWork.TL.DAL.Shared
{
    [Export(typeof(IModule))]
    public class DataAccessSharedModule : IModule
    {
        private DependencyInjectionConfiguration dependencyInjectionConfiguration;

        public void Initialize(IUnityContainer container)
        {
            dependencyInjectionConfiguration = new DependencyInjectionConfiguration(container);
            dependencyInjectionConfiguration.Configure();
        }
    }
}
