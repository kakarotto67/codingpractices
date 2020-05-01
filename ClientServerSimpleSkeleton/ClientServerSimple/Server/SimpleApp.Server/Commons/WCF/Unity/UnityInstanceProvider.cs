using SimpleApp.Server.Commons.Ioc;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace SimpleApp.Server.Commons.WCF.Unity
{
  public class UnityInstanceProvider : IInstanceProvider
  {
    private Type ServiceType { set; get; }

    public UnityInstanceProvider(Type serviceType)
    {
      ServiceType = serviceType;
    }

    public object GetInstance(InstanceContext instanceContext)
    {
      return GetInstance(instanceContext, null);
    }

    public object GetInstance(InstanceContext instanceContext, Message message)
    {
      return DependencyInjection.Container.Resolve(ServiceType, string.Empty);
    }

    public void ReleaseInstance(InstanceContext instanceContext, object instance)
    {
    }
  }
}
