﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Construction.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            AreaRegistration.RegisterAllAreas();

            routes.MapRoute(
               name: "Admin",
               url: "admin",
               defaults: new { controller = "DashBoard", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "Construction.Web.Areas.Admin.Controllers" }
            );
            /* ****************************************** Product ***************************************************/
            routes.MapRoute(
               name: "ProductDetail",
               url: "mau-thiet-ke/{alias}-{id}",
               defaults: new
               {
                   controller = "FE_Product",
                   action = "Detail",
                   alias = UrlParameter.Optional,
                   id = UrlParameter.Optional
               },
               namespaces: new[] { "Construction.Web.Controllers" }
            );

            routes.MapRoute(
               name: "Product",
               url: "mau-thiet-ke/{pageNumber}",
               defaults: new { controller = "FE_Product", action = "Index", pageNumber = UrlParameter.Optional },
               namespaces: new[] { "Construction.Web.Controllers" }
            );



            /* ******************************************  ***************************************************/

            /* ****************************************** Project ***************************************************/

            routes.MapRoute(
               name: "ProjectDetail",
               url: "du-an/{alias}-{id}",
               defaults: new
               {
                   controller = "FE_Project",
                   action = "Detail",
                   alias = UrlParameter.Optional,
                   id = UrlParameter.Optional
               },
               namespaces: new[] { "Construction.Web.Controllers" }
            );

            routes.MapRoute(
               name: "Project",
               url: "du-an/{pageNumber}",
               defaults: new { controller = "FE_Project", action = "Index", pageNumber = UrlParameter.Optional },
               namespaces: new[] { "Construction.Web.Controllers" }
            );

            /* ******************************************  ***************************************************/
            routes.MapRoute(
               name: "About",
               url: "gioi-thieu",
               defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
               namespaces: new[] { "Construction.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional },
                namespaces: new[] { "Construction.Web.Controllers" }
            );

            routes.MapRoute(
                 name: "Default",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "Construction.Web.Controllers" }
             );
        }
    }
}
