using System.Web.Http;
using System.Web.Http.Dispatcher;
using LORE.WebApi.Objects.Controllers;
using LORE.WebApi.Services.Injection;

namespace LORE.WebApi.Objects.Configure
{
    public static class Configuration
    {
        public static HttpConfiguration GetConfiguration()
        {
            var config = new HttpConfiguration();

            // Inject Assemblies with Controller logic.
            config.Services.Replace(typeof(IAssembliesResolver), 
                AssemblyInjectionService.Initialize()
                    .RegisterAssembly(typeof(WeaponController))
            );
            
            config.Routes.MapHttpRoute(
                "LORE.WebApi.Objects.Routes", 
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );
            return config;
        }
    }
}
