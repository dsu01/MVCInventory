using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MVCInventory.WebUI.App_Start;

namespace MVCInventory.WebUI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Register Unity with Web API.
            var container = UnityConfig.Config();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
