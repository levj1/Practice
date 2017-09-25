using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrgNClean.Startup))]
namespace OrgNClean
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
