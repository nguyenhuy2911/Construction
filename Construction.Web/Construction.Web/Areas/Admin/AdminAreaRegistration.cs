using System.Web.Mvc;

namespace Construction.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            /*              Category                      */
            context.MapRoute(
               name: "Category",
               url: "admin/danh-muc",
               defaults: new { controller = "Category", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "Construction.Web.Areas.Admin.Controllers" }
            );
                       
            context.MapRoute(
               name: "GetCategories",
               url: "admin/category/getlist",
               defaults: new { controller = "Category", action = "Categories", id = UrlParameter.Optional },
               namespaces: new[] { "Construction.Web.Areas.Admin.Controllers" }
            );
            /*          End  Category                      */

            context.MapRoute(
               name: "Admin",
               url: "admin",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "Construction.Web.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                 "Admin_default",
                 "Admin/{controller}/{action}/{id}",
                 new { action = "Index", id = UrlParameter.Optional }
             );
        }
    }
}