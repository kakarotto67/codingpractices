using System.Linq;
using SimpleApp.Server.Domain;
using SimpleApp.Server.Dto;
using System.Collections.Generic;

namespace SimpleApp.Server.Mappings
{
  public class AppleMapping
  {
    public AppleDto MapToDto(Apple apple)
    {
      if (apple != null)
      {
        return new AppleDto
          {
            Id = apple.Id,
            SortName = apple.SortName,
            Color = apple.Color,
            Size = apple.Size
          };
      }
      return null;
    }

    public IList<AppleDto> MapToDto(IList<Apple> apples)
    {
      return apples != null ? apples.Select(MapToDto).ToList() : null;
    }
  }
}
