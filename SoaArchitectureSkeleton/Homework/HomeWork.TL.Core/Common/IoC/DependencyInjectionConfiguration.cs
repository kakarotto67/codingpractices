using Microsoft.Practices.Unity;

namespace HomeWork.TL.Core.Common.IoC
{
    public class DependencyInjectionConfiguration
    {
        private readonly IUnityContainer container;

        public DependencyInjectionConfiguration(IUnityContainer container)
        {
            this.container = container;
        }
    }
}
