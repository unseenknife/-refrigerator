using Fridge.Controllers;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Fridge.Startup))]

namespace Fridge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}