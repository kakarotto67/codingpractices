using SimpleApp.Client.Domain.Model;
using System;
using System.Collections.Generic;

namespace SimpleApp.Client.Domain.ServiceAgents.Abstract
{
  public interface IAppleServiceAgent
  {
    void GetApples(Action<IList<Apple>> resultHandler, Action<Exception> errorHandler);
  }
}
