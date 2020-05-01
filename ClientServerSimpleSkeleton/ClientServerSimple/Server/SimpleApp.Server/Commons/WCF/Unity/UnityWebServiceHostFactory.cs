using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;

namespace SimpleApp.Server.Commons.WCF.Unity
{
  public class UnityWebServiceHostFactory : WebServiceHostFactory
  {
    private readonly ICollection<IServiceBehavior> serviceBehaviors;

    public UnityWebServiceHostFactory(ICollection<IServiceBehavior> serviceBehaviors)
    {
      this.serviceBehaviors = serviceBehaviors;
    }

    protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
    {
      var unityWebServiceHost = new UnityWebServiceHost(serviceBehaviors, serviceType, baseAddresses);
      return unityWebServiceHost;
    }
  }
}
