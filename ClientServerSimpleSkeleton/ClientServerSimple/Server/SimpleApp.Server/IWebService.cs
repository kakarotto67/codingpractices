using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using SimpleApp.Server.Dto;

namespace SimpleApp.Server
{
  [ServiceContract]
  public interface IWebService
  {
    [WebGet(UriTemplate = "apples")]
    IList<AppleDto> GetApples();
  }
}
