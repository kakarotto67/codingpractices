using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace SimpleApp.Server.Commons.WCF.NHibernate
{
  public class NHibernateUnitOfWorkServiceBehavior : IServiceBehavior
  {
    public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
    }

    public void AddBindingParameters(ServiceDescription serviceDescription,
                                     ServiceHostBase serviceHostBase,
                                     Collection<ServiceEndpoint> endpoints,
                                     BindingParameterCollection bindingParameters)
    {
    }

    public void ApplyDispatchBehavior(ServiceDescription serviceDescription,
                                      ServiceHostBase serviceHostBase)
    {
      foreach (
        var endpoint in
          serviceHostBase.ChannelDispatchers.Cast<ChannelDispatcher>()
                         .SelectMany(channelDispatcher => channelDispatcher.Endpoints))
      {
        endpoint.DispatchRuntime.MessageInspectors.Add(new NHibernateUnitOfWorkMessageInspector());
      }
    }
  }
}
