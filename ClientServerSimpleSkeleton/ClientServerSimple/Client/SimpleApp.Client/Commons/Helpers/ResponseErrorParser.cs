using RestSharp;
using System;
using System.Net;

namespace SimpleApp.Client.Commons.Helpers
{
  public static class ResponseErrorParser
  {
    public static Exception CheckIfExceptionOccured(IRestResponse response)
    {
      Exception result = null;
      if ((int) response.StatusCode == 0)
      {
        result = new Exception(response.ErrorMessage);
      }
      else
        switch (response.StatusCode)
        {
          case HttpStatusCode.InternalServerError:
            result = new Exception("InternalServerError");
            break;
          case HttpStatusCode.NotFound:
            result = new Exception("NotFound");
            break;
          case HttpStatusCode.BadRequest:
            result = new Exception("BadRequest");
            break;
          default:
            if (response.StatusCode != HttpStatusCode.OK
                && response.StatusCode != HttpStatusCode.Created)
            {
              result = new Exception(response.StatusDescription);
            }
            else if (response.ErrorException != null)
            {
              result = response.ErrorException;
            }
            else if (response.ResponseStatus != ResponseStatus.Completed)
            {
              result = new Exception("Response Status is - " + response.ResponseStatus);
            }
            break;
        }

      return result;
    }
  }
}
