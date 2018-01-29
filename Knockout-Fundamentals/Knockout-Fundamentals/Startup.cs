using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Knockout_Fundamentals.Startup))]
namespace Knockout_Fundamentals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
