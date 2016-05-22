using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MasterMind.WebAPI.Startup))]

namespace MasterMind.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
            
        }

    }
}
