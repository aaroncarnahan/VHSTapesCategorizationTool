using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VTCT.WebMVC.Startup))]
namespace VTCT.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
