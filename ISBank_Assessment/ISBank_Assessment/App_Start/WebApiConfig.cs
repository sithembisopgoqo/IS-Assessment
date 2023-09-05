using ISBank_Assessment.Filters;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace ISBank_Assessment
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            //TODO  ElmahExceptionLogger- logging errors in an ASP.NET web application
            //config.Services.Add(typeof(IExceptionLogger), new ElmahExceptionLogger());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
