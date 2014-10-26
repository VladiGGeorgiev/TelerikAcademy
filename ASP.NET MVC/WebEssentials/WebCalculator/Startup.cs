using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCalculator.Startup))]
namespace WebCalculator
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
