using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyShhop.WebUI.Startup))]
namespace MyShhop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
