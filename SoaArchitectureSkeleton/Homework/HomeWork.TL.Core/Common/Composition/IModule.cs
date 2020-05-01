using Microsoft.Practices.Unity;

namespace HomeWork.TL.Core.Common.Composition
{
    public interface IModule
    {
        void Initialize(IUnityContainer container);
    }
}
