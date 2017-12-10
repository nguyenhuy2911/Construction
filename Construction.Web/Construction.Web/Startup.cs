
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Construction.Web.Startup))]
namespace Construction.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           
        }
    }
}
