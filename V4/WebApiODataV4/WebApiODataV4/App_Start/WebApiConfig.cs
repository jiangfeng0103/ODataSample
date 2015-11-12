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

            //构建路由服务
            var route = config.MapODataServiceRoute("odata", "Odata", model: GetModel()); //第二个参数Odata是前缀
        }


        public static Microsoft.OData.Edm.IEdmModel GetModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            builder.EntitySet<Supplier>("Suppliers");

            //配置一个函数
            //builder.EntitySet<Product>("Products").EntityType.Collection.Function("MostExpensive").Returns<double>(); //获取最贵产品价格的路由设置 


            //配置一个Action
            //builder.EntitySet<Product>("Products").EntityType.Action("Rate").Parameter<int>("Rating");

            #region 服务的另一种配置方法
            //http://www.asp.net/web-api/overview/odata-support-in-aspnet-web-api/odata-v4/odata-actions-and-functions
            builder.Namespace = "ProductService";
            builder.EntityType<Product>().Collection
                .Function("MostExpensive")  //函数路由
                .Returns<double>();

            builder.Namespace = "ProductService";
            builder.EntityType<Product>()
                .Action("Rate")  //Action路由
                .Parameter<int>("Rating");
            #endregion

            return builder.GetEdmModel();
        }
    }
}
