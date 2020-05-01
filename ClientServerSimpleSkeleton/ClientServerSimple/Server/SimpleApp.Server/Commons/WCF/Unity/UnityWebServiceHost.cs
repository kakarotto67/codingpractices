using System;
using System.Collections.Generic;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace SimpleApp.Server.Commons.WCF.Unity
{
  public class UnityWebServiceHost : WebServiceHost
  {
    private readonly ICollection<IServiceBehavior> serviceBehaviors;

    public UnityWebServiceHost(ICollection<IServiceBehavior> serviceBehaviors)
    {
      this.serviceBehaviors = serviceBehaviors;
    }

    public UnityWebServiceHost(ICollection<IServiceBehavior> serviceBehaviors,
                               object singletonInstance,
                               params Uri[] baseAddresses)
      : base(singletonInstance, baseAddresses)
    {
      this.serviceBehaviors = serviceBehaviors;
    }


    public UnityWebServiceHost(ICollection<IServiceBehavior> serviceBehaviors,
                               Type serviceType,
                               params Uri[] baseAddresses)
      : base(serviceType, baseAddresses)
    {
      this.serviceBehaviors = serviceBehaviors;
    }

    protected override void OnOpening()
    {
      base.OnOpening();
      foreach (var serviceBehavior in serviceBehaviors)
      {
        Description.Behaviors.Add(serviceBehavior);
      }
    }
  }
}
