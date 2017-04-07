using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartHub.Startup))]
namespace SmartHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
