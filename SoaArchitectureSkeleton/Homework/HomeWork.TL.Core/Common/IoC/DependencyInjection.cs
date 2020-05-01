using Microsoft.Practices.Unity;

namespace HomeWork.TL.Core.Common.IoC
{
    /// <summary>
    /// The Container.
    /// </summary>
    public static class DependencyInjection
    {
        public static IUnityContainer Container = new UnityContainer();

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
