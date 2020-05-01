using RestSharp;
using RestSharp.Deserializers;
using SimpleApp.Client.Commons.Helpers;
using System;
using System.Threading.Tasks;

namespace SimpleApp.Client.Commons.Rest
{
  public abstract class ServiceClient : IServiceClient
  {
    private readonly string baseUrl;
    private readonly int timeout;

    protected ServiceClient(string baseUrl, int timeout)
    {
      this.baseUrl = baseUrl;
      this.timeout = timeout;
    }

    /// <summary>
    /// Calls service, specified by <paramref name="url"/> with GET method asynchronously.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="url"></param>
    /// <param name="resultHandler"></param>
    /// <param name="errorHandler"></param>
    public void Get<T>(string url, Action<T> resultHandler, Action<Exception> errorHandler) where T : new()
    {
      try
      {
        //Task.Factory.StartNew(() =>
        //  {
        var restClient = CreateRestClient();
        var restRequest = new RestRequest {Resource = url};
        var response = restClient.Execute<T>(restRequest);

        var exception = ResponseErrorParser.CheckIfExceptionOccured(response);

        if (exception != null)
        {
          errorHandler(exception);
        }
        else
        {
          resultHandler(response.Data);
        }
        //});
      }
      catch (Exception e)
      {
        errorHandler(e);
      }
    }

    /// <summary>
    /// Create REST client.
    /// </summary>
    /// <returns></returns>
    private RestClient CreateRestClient()
    {
      var restClient = new RestClient {BaseUrl = baseUrl, Timeout = timeout};
      restClient.AddHandler("application/xml", new DotNetXmlDeserializer());
      restClient.AddHandler("text/xml", new DotNetXmlDeserializer());
      return restClient;
    }
  }
}
