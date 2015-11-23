using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EGE.Web.Startup))]
namespace EGE.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
