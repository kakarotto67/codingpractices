using SimpleApp.Client.Commons.Rest;
using SimpleApp.Client.Domain.Mappings;
using SimpleApp.Client.Domain.Model;
using SimpleApp.Client.Domain.ServiceAgents.Abstract;
using SimpleApp.Client.ServiceModel;
using System;
using System.Collections.Generic;

namespace SimpleApp.Client.Domain.ServiceAgents
{
  public class AppleServiceAgent : ReadOnlyServiceAgent<AppleDto, Apple>, IAppleServiceAgent
  {
    public AppleServiceAgent(ISimpleAppServiceClient serviceClient,
                             IMapping<AppleDto, Apple> mapping)
      : base(serviceClient, mapping)
    {
    }

    public void GetApples(Action<IList<Apple>> resultHandler,
                          Action<Exception> errorHandler)
    {
      Get("apples", resultHandler, errorHandler);
    }
  }
}
