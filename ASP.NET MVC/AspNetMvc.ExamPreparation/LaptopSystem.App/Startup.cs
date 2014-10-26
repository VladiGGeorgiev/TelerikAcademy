using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaptopSystem.App.Startup))]
namespace LaptopSystem.App
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
