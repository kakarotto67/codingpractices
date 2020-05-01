using SimpleApp.Client.Domain.Model;
using System;

namespace SimpleApp.Client.Client
{
  public class SimpleClient
  {
    private readonly IApplesProvider applesProvider;

    public SimpleClient(IApplesProvider applesProvider)
    {
      this.applesProvider = applesProvider;
    }

    public void ShowApples()
    {
      var apples = applesProvider.GetApples();
      if (apples == null) return;
      foreach (var apple in apples)
      {
        Console.WriteLine(PrintApple(apple));
      }
    }

    private static string PrintApple(Apple apple)
    {
      return string.Format("Apple with Id: {0}, Sort name: {1}, Color: {2} and Size: {3}",
                           apple.Id, apple.SortName, apple.Color, apple.Size);
    }
  }
}
