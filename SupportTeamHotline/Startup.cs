using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SupportTeamHotline.Startup))]
namespace SupportTeamHotline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
