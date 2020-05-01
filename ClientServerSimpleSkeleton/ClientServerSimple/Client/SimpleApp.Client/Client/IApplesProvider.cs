using SimpleApp.Client.Domain.Model;
using System.Collections.Generic;

namespace SimpleApp.Client.Client
{
  public interface IApplesProvider
  {
    IList<Apple> GetApples();
  }
}
