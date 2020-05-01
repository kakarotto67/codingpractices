using System.Configuration;

namespace SimpleApp.Client.Commons.Helpers
{
  public static class ConfigurationHelper
  {
    public static string GetServiceBaseAddress()
    {
      return ConfigurationManager.AppSettings["ServiceBaseAddress"];
    }

    public static int GetTimeout()
    {
      return int.Parse(ConfigurationManager.AppSettings["Timeout"]);
    }
  }
}
