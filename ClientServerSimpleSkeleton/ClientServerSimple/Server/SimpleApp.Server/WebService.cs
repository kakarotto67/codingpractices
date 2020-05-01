using System.Collections.Generic;
using SimpleApp.Server.Dto;
using SimpleApp.Server.Mappings;
using SimpleApp.Server.Repositories.Interfaces;
using System.ServiceModel;

namespace SimpleApp.Server
{
  [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
  public class WebService : IWebService
  {
    private readonly IAppleRepository appleRepository;
    private readonly AppleMapping appleMapping;

    public WebService(IAppleRepository appleRepository, AppleMapping appleMapping)
    {
      this.appleRepository = appleRepository;
      this.appleMapping = appleMapping;
    }

    public WebService()
    {
    }

    public IList<AppleDto> GetApples()
    {
      var apples = appleRepository.GetAll();
      return appleMapping.MapToDto(apples);
    }
  }
}
