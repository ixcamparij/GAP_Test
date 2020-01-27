using Domain_Data;
using Domain_Data.Data;
using Domain_Data.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;

namespace WebAPI_Test_GAP.Configuration
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional});

            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<IPolicyRepository, PolicyRepository>();
            container.RegisterType<IDataBaseConnector, DataBaseConnector>();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}