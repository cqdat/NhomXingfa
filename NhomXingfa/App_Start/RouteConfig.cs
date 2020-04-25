﻿using System;
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
                url: "chi-tiet/{url}-{id}",
                defaults: new { controller = "product", action = "detail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "tintuc",
               url: "tin-tuc/{url}-{id}",
               defaults: new { controller = "news", action = "index", id = UrlParameter.Optional }
           );

            //các bài viết
            routes.MapRoute(
               name: "baiviet",
               url: "bai-viet/{url}-{id}",
               defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
           );

            routes.MapRoute(
            name: "chitietduan",
            url: "ch-tiet-du-an/{url}-{id}",
            defaults: new { controller = "projects", action = "details", id = UrlParameter.Optional }
        );

            routes.MapRoute(
              name: "duan",
              url: "du-an",
              defaults: new { controller = "projects", action = "index", id = UrlParameter.Optional }
          );

           

            routes.MapRoute(
                name: "chitiettt",
                url: "chi-tiet-tin-tuc/{url}-{id}",
                defaults: new { controller = "news", action = "detail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            

        }
    }
}
