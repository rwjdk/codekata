using JetBrains.Annotations;
using Microsoft.Owin.Cors;
using Owin;

namespace Communication.SignalR.Model
{
    public class SignalRStartupConfiguration
    {
        [UsedImplicitly]
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}