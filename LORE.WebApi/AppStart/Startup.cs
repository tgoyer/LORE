using LORE.WebApi.AppStart;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace LORE.WebApi.AppStart
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWebApi(Objects.Configure.Configuration.GetConfiguration());
        }
    }
}
