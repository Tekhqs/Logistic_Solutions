using System.Web;
using System.Web.Optimization;

namespace LogisticSolutions
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                    "~/Scripts/LS/main.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
         "~/Scripts/Jquery-3.4.1.js",
          "~/Scripts/umd/popper.min.js",
         "~/Scripts/bootstrap.min.js",
         "~/Scripts/respond.min.js",
         "~/Scripts/jquery.validate.min.js",

              "~/Scripts/kendo/kendo.all.min.js",
          "~/Scripts/kendo/kendo.web.min.js",
          "~/Scripts/kendo/kendo.aspnetmvc.min.js",
         "~/Scripts/moment.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                       "~/Content/StyleLS.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
              "~/Content/kendo/kendo.common.min.css", "~/Content/kendo/kendo.material.min.css"));
        }
    }
}
