using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(myPosTask.Startup))]
namespace myPosTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
