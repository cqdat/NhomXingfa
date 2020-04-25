using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NhomXingfa
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "product",
                 url: "san-pham",
                 defaults: new { controller = "product", action = "index", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                 name: "product2",
                 url: "san-pham/{url}-{id}",
                 defaults: new { controller = "product", action = "index", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                name: "chitiet",
                url: "chi-tiet-san-pham/{url}-{id}",
                defaults: new { controller = "product", action = "detail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "tintuc",
               url: "tin-tuc/{url}-{id}",
               defaults: new { controller = "news", action = "index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            

        }
    }
}
