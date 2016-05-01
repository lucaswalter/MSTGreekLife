using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MSTGreekLife.Startup))]
namespace MSTGreekLife
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
