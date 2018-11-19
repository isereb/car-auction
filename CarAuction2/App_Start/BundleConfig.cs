using System.Web.Optimization;

namespace CarAuction2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/styles").Include(
                "~/Content/styles/bootstrap.css",
                "~/Content/styles/site.css"
            ));

            bundles.Add(new ScriptBundle("~/scripts").Include(
                "~/Content/scripts/jquery-{version}.js",
                "~/Content/scripts/bootstrap.js"
            ));
        }
    }
}