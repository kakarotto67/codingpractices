using System;

namespace SimpleApp.Client.Commons.Rest
{
  public interface IServiceClient
  {
    void Get<T>(string url, Action<T> resultHandler, Action<Exception> errorHandler) where T : new();
  }
}
