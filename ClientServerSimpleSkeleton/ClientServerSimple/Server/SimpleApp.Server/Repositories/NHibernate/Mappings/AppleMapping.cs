using FluentNHibernate.Mapping;
using SimpleApp.Server.Domain;

namespace SimpleApp.Server.Repositories.NHibernate.Mappings
{
  public class AppleMapping : ClassMap<Apple>
  {
    public AppleMapping()
    {
      Id(x => x.Id);
      Map(x => x.SortName).Not.Nullable();
      Map(x => x.Color).Not.Nullable();
      Map(x => x.Size).Not.Nullable();
    }
  }
}
