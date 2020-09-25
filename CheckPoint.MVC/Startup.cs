using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheckPoint.MVC.Startup))]
namespace CheckPoint.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
