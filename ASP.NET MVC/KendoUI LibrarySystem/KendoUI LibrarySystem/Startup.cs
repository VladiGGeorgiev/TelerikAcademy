using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KendoUI_LibrarySystem.Startup))]
namespace KendoUI_LibrarySystem
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
