using Ninject;
using Ninject.Extensions.Wcf;
using Ninject.Infrastructure;
using System;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace SimpleApp.Server.Commons.Ninject
{
  public abstract class NinjectWcfApplication : HttpApplication, IHaveKernel
  {
    private static IKernel kernel;

    public IKernel Kernel
    {
      get { return kernel; }
    }

    protected virtual void Application_Start(object sender, EventArgs e)
    {
      lock (this)
      {
        kernel = CreateKernel();
        KernelContainer.Kernel = kernel;
        RegisterCustomBehavior();
        OnApplicationStarted();
      }
    }

    protected abstract IKernel CreateKernel();

    protected virtual void RegisterCustomBehavior()
    {
      if (!kernel.GetBindings(typeof (ServiceHost)).Any())
      {
        kernel.Bind<ServiceHost>().To<NinjectServiceHost>();
      }
    }

    protected virtual void Application_End(object sender, EventArgs e)
    {
      lock (this)
      {
        if (kernel != null)
        {
          kernel.Dispose();
          kernel = null;
        }

        OnApplicationStopped();
      }
    }

    protected virtual void OnApplicationStarted()
    {
    }

    protected virtual void OnApplicationStopped()
    {
    }
  }
}
