using System.Web;
using System.Web.Optimization;

namespace SiteDeVente
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/GlobalScripts").Include(
                "~/node_modules/jquery/dist/jquery.js",
                "~/node_modules/bootstrap/dist/js/bootstrap.js",
                      "~/Content/Scripts/Layout.js",
                        "~/node_modules/jquery/src/jquery.unobtrusive-ajax.js"
                      ));

            bundles.Add(new StyleBundle("~/bundles/GlobalStyles").Include(
                     "~/node_modules/bootstrap/dist/css/bootstrap.min.css",
                      "~/Content/Styles/Layout.css"));
        }
    }
}
