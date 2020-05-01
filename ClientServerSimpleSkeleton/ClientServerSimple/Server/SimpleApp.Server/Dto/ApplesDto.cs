using System.Collections.Generic;

namespace SimpleApp.Server.Dto
{
  public class ApplesDto
  {
    public IList<AppleDto> Apples { get; set; }

    public ApplesDto()
    {
      Apples = new List<AppleDto>();
    }
  }
}
