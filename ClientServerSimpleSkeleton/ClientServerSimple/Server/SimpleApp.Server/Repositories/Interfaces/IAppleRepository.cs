using System.Collections.Generic;
using SimpleApp.Server.Domain;

namespace SimpleApp.Server.Repositories.Interfaces
{
  public interface IAppleRepository
  {
    IList<Apple> GetAll();
  }
}
