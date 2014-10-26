using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamPreparationPollSystem.Startup))]
namespace ExamPreparationPollSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
