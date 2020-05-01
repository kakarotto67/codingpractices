using System.Web.Optimization;

namespace GCBL.CoreSite
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/jquerymin").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/scripts/skel").Include(
                        "~/Scripts/skel.min.js",
                        "~/Scripts/skel-viewport.min.js"));

            bundles.Add(new ScriptBundle("~/scripts/util").Include(
                        "~/Scripts/util.js"));

            bundles.Add(new ScriptBundle("~/scripts/main").Include(
                        "~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/styles/main").Include(
                      "~/Styles/main.css",
                      "~/Styles/extra.css"));

            // Enable bundling & minification
            BundleTable.EnableOptimizations = true;
        }
    }
}