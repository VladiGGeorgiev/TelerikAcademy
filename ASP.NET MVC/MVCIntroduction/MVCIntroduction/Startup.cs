using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCIntroduction.Startup))]
namespace MVCIntroduction
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
