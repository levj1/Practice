using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CF.WebMVC.Startup))]
namespace CF.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
