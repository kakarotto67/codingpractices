using SimpleApp.Client.Commons.Helpers;

namespace SimpleApp.Client.Commons.Rest
{
  public class SimpleAppServiceClient : ServiceClient, ISimpleAppServiceClient
  {
    public SimpleAppServiceClient()
      : base(ConfigurationHelper.GetServiceBaseAddress(), ConfigurationHelper.GetTimeout())
    {
    }
  }
}
