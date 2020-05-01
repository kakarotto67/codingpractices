using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeWork.TL.WebSite.Startup))]
namespace HomeWork.TL.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
