using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MalweeCodeChallenge.Startup))]
namespace MalweeCodeChallenge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
