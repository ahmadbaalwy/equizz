using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(wajeb004.Startup))]
namespace wajeb004
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
