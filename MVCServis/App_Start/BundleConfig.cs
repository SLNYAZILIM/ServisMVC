using System.Web;
using System.Web.Optimization;

namespace MVCServis
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/jquery.easing.1.3.js",
                      "~/Scripts/jquery.style.switcher.js",
                      "~/Scripts/jquery.waypoints.min.js",
                      "~/Scripts/main.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/AdminNavbar.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/animate.css",
                "~/Content/blue.css",                      
                "~/Content/bootstrap.min.css",
                      "~/Content/footer.css",
                      "~/Content/Navbar.css",
                      "~/Content/slider.css",
                      "~/Content/site.css",
                      "~/Content/navbaradmin.css",
                      "~/Content/Giris.css",
                      "~/Content/Tablolar.css",
                      "~/Content/icomoon.css",
                      "~/Content/style.css"
                      ));
        }
    }
}
