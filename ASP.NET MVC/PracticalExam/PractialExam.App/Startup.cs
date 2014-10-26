using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PractialExam.App.Startup))]
namespace PractialExam.App
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
