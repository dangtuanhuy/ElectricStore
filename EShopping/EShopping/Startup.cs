using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EShopping.Startup))]
namespace EShopping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
