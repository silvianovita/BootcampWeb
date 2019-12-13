using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bootcamp32ASP.Startup))]
namespace Bootcamp32ASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
