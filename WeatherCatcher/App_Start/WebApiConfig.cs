using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Unity.WebApi;
using WeatherCatcher.Models;

namespace WeatherCatcher
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{Name}",
                defaults: new { Name = RouteParameter.Optional }
            );
        }
    }
}
