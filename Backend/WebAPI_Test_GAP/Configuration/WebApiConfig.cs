using Domain.Data;
using Domain.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;

namespace WebAPI_Test_GAP.Configuration
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional});

            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<IPolicyRepository, PolicyRepository>();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}