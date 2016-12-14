using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestServiceWhitoutProxySite.Startup))]
namespace TestServiceWhitoutProxySite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
