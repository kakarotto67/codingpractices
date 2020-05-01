using Ninject;
using System;

namespace SimpleApp.Server.Commons.Ninject
{
  public class KernelContainer
  {
    private static IKernel kernel;

    public static IKernel Kernel
    {
      get { return kernel; }
      set
      {
        if (kernel != null)
        {
          throw new NotSupportedException("The static container already has a kernel associated with it!");
        }

        kernel = value;
      }
    }

    public static void Inject(object instance)
    {
      if (kernel == null)
      {
        throw new InvalidOperationException(String.Format(
          "The type {0} requested an injection, but no kernel has been registered for the web application.\r\n" +
          "Please ensure that your project defines a NinjectHttpApplication.",
          instance.GetType()));
      }

      kernel.Inject(instance);
    }
  }
}
