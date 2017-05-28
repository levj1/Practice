using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChurchAppsWeb.Startup))]
namespace ChurchAppsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
