
namespace SimpleApp.Client.Domain.Mappings
{
  public interface IMapping<TDto, TDomain>
  {
    TDto MapToDto(TDomain domain);

    TDomain MapToDomain(TDto dto);
  }
}
