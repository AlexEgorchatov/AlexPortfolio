using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlexPortfolio.Startup))]
namespace AlexPortfolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
