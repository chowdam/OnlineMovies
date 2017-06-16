using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineMovies.Web.Startup))]
namespace OnlineMovies.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
