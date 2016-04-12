using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEM.Startup))]
namespace SEM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
