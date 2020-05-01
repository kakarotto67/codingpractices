using System;

namespace SimpleApp.Server
{
  public class Global : System.Web.HttpApplication //NinjectWcfApplication
  {
    private BootStrapper bootStrapper;
    //private IKernel kernel;

    protected void Application_Start(object sender, EventArgs e)
    {
      bootStrapper = new BootStrapper();
      bootStrapper.Initialize();
    }

    //protected override void Application_Start(object sender, EventArgs e)
    //{
    //  base.Application_Start(sender, e);

    //  bootStrapper = new BootStrapper();
    //  bootStrapper.Initialize();

    //  StartWebService();
    //}

    //protected override IKernel CreateKernel()
    //{
    //  return GetKernel();
    //}

    //private void StartWebService()
    //{
    //  var webServiceHostFactory = new NinjectWebServiceHostFactory();
    //  BaseNinjectServiceHostFactory.SetKernel(GetKernel());
    //  RouteTable.Routes.Add(new ServiceRoute("Api",
    //                                         webServiceHostFactory,
    //                                         typeof (WebService)));
    //}

    //private IKernel GetKernel()
    //{
    //  return kernel ?? (kernel = new StandardKernel(new NinjectServiceModule()));
    //}
  }
}
