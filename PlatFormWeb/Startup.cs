using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlatFormWeb.Startup))]
namespace PlatFormWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
