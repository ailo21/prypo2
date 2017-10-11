using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(prypo2.Startup))]
namespace prypo2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
