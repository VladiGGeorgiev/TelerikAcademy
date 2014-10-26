using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticalExam.Startup))]
namespace PracticalExam
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
