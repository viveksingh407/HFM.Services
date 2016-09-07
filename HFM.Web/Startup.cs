using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HFM.Web.Startup))]
namespace HFM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
