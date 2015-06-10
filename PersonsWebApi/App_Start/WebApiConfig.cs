using System.Web.Http;

namespace PersonsWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "PersonList",
                routeTemplate: "api/data/person",
                defaults: new { controller = "Data", action = "GetPeople" }
            );

            config.Routes.MapHttpRoute(
                name: "PersonFilter",
                routeTemplate: "api/data/person/filter",
                defaults: new { controller = "Data", action = "Filter" }
            );

            config.Routes.MapHttpRoute(
                name: "RandomPerson",
                routeTemplate: "api/data/person/random",
                defaults: new { controller = "Data", action = "PutRandomPerson" }
            );

            config.EnableSystemDiagnosticsTracing();
        }
    }
}
