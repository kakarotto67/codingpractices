using Microsoft.Practices.Unity;
using SimpleApp.Client.Client;
using SimpleApp.Client.Commons.IoC;
using System;

namespace SimpleApp.Client
{
  public class Program
  {
    private static void Main()
    {
      // configure IoC
      var dependencyInjectionConfiguration = new DependencyInjectionConfiguration(DependencyInjection.Container);
      dependencyInjectionConfiguration.Configure();

      // some client logic
      var client = new SimpleClient(DependencyInjection.Container.Resolve<ApplesProvider>());
      client.ShowApples();

      // wait for key press
      Console.ReadKey();
    }
  }
}
