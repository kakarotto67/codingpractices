using SimpleApp.Client.Domain.Model;
using SimpleApp.Client.ServiceModel;

namespace SimpleApp.Client.Domain.Mappings
{
  public class AppleMapping : IMapping<AppleDto, Apple>
  {
    public AppleDto MapToDto(Apple domain)
    {
      if (domain != null)
      {
        return new AppleDto
          {
            Id = domain.Id,
            SortName = domain.SortName,
            Color = domain.Color,
            Size = domain.Size
          };
      }
      return null;
    }

    public Apple MapToDomain(AppleDto dto)
    {
      if (dto != null)
      {
        return new Apple
          {
            Id = dto.Id,
            SortName = dto.SortName,
            Color = dto.Color,
            Size = dto.Size
          };
      }
      return null;
    }
  }
}
