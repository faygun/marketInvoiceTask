using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Unity;
using LoanApi.App_Start;
using LoanApi.Services;

namespace LoanApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ILoanService, LoanService>().Resolve<LoanService>();
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Formatters.JsonFormatter.SupportedMediaTypes
            //.Add(new MediaTypeHeaderValue("application/json"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
