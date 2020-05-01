using SimpleApp.Client.Domain.Model;
using SimpleApp.Client.Domain.ServiceAgents.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleApp.Client.Client
{
  public class ApplesProvider : IApplesProvider
  {
    private readonly IAppleServiceAgent appleServiceAgent;

    public ApplesProvider(IAppleServiceAgent appleServiceAgent)
    {
      this.appleServiceAgent = appleServiceAgent;
    }

    public IList<Apple> GetApples()
    {
      //IList<Apple> result = null;
      //appleServiceAgent.GetApples(
      //  resultHandler => { result = resultHandler; },
      //  ex => Console.WriteLine(ex.Message));
      //return result;
      //return GetApplesAsynchronously().Result;
      return GetApplesAsynchronously();
    }

    private IList<Apple> GetApplesAsynchronously()
    {
      IList<Apple> result = null;
      appleServiceAgent.GetApples(resultHandler => 
        {
          result = resultHandler;
        },
        ex => Console.WriteLine(ex.Message));
      return result;
    }
  }
}
