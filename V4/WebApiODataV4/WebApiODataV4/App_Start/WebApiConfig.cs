using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Routing;
using WebApiODataV4.Models;

namespace WebApiODataV4
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var route = config.MapODataServiceRoute("odata", "Odata", model: GetModel());
        }


        public static Microsoft.OData.Edm.IEdmModel GetModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            builder.EntitySet<Supplier>("Suppliers");
            return builder.GetEdmModel();
        }
    }
}
