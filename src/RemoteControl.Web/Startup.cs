using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RemoteControl.Web.Startup))]

namespace RemoteControl.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
