using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;

namespace SimpleApp.Server.Repositories.NHibernate
{
  public class NHibernateConfiguration
  {
    public static ISessionFactory SessionFactory { get; set; }

    public static void Initialize()
    {
      SessionFactory = CreateSessionFactory();
    }

    /// <summary>
    /// Create session factory.
    /// </summary>
    /// <returns>Return ISessionFactory object.</returns>
    private static ISessionFactory CreateSessionFactory()
    {
      var fluentConfiguration = Fluently.Configure()
                                        .Database(
                                          MsSqlConfiguration.MsSql2008.ConnectionString(
                                            c => c.FromConnectionStringWithKey("SimpleAppDatabase")))
                                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateConfiguration>())
                                        //.ExposeConfiguration(cfg =>
                                        //  {
                                        //    var configuration = cfg;
                                        //    cfg.SetProperty("transaction.factory_class", "NHibernate.Transaction.AdoNetTransactionFactory");
                                        //    cfg.SetProperty("adonet.batch_size", "100");
                                        //    cfg.SetProperty("command_timeout", "10000");
                                        //    cfg.SetProperty("hibernate.default_schema", "SimpleAppDb.dbo");
                                        //    var update = new SchemaUpdate(configuration);
                                        //    update.Execute(false, true);
                                        //  })
                                        .CurrentSessionContext<WcfOperationSessionContext>();

      var sessionFactory = fluentConfiguration.BuildSessionFactory();
      return sessionFactory;
    }
  }
}
