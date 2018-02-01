using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StreakProject.Web.Startup))]
namespace StreakProject.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
