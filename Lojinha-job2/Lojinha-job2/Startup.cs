using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lojinha_job2.Startup))]
namespace Lojinha_job2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
