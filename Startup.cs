using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lagu.Startup))]
namespace lagu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            
        }
    }
}
