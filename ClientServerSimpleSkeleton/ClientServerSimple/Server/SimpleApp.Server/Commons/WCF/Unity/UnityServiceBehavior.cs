using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace SimpleApp.Server.Commons.WCF.Unity
{
  public class UnityServiceBehavior : IServiceBehavior
  {
    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
      foreach (var cdb in serviceHostBase.ChannelDispatchers)
      {
        var cd = cdb as ChannelDispatcher;
        if (cd == null) continue;
        foreach (var ed in cd.Endpoints)
        {
          ed.DispatchRuntime.InstanceProvider = new UnityInstanceProvider(serviceDescription.ServiceType);
        }
      }
    }

    public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
    }

    public void AddBindingParameters(ServiceDescription serviceDescription,
                                     ServiceHostBase serviceHostBase,
                                     Collection<ServiceEndpoint> endpoints,
                                     BindingParameterCollection bindingParameters)
    {
    }
  }
}
