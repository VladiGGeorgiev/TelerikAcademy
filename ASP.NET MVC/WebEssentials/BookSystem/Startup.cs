using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookSystem.Startup))]
namespace BookSystem
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
