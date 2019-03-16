using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentalApp.Startup))]
namespace RentalApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
