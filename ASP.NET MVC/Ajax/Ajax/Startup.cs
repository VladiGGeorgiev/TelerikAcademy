using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ajax.Startup))]
namespace Ajax
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
