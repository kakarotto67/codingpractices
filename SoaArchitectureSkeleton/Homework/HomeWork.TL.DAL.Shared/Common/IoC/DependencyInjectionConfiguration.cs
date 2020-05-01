using Microsoft.Practices.Unity;

namespace HomeWork.TL.DAL.Shared.Common.IoC
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
        }
    }
}
