using System.Web;
using System.Web.Optimization;

namespace Construction.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/asset/css/bootstrap.css",
                      "~/asset/css/responsive.css",
                      "~/asset/css/camera.css",
                      "~/asset/css/flexslider.css",
                      "~/asset/css/owl.carousel.css",
                      "~/asset/css/owl.theme.css",
                      "~/asset/font-awesome/css/font-awesome.css",
                      "~/asset/css/cherry-plugin.css",
                      "~/asset/css/magnific-popup.css",
                      "~/asset/css/main-style.css",
                      "~/asset/css/customstyle.css",
                      "~/asset/css/flaticon.css",
                      "~/asset/css/animate.css"));
           // BundleTable.EnableOptimizations = true;
        }
    }
}
