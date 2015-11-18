using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Ninject_MVC_WebApi
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

            //disable xmlformat, use json
            config.Formatters.Remove(config.Formatters.XmlFormatter);

           
            //prevent serialization circular references
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}
