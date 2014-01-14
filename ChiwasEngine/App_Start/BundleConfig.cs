using System.Web;
using System.Web.Optimization;

namespace ChiwasEngine
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/css/ChiwasEngine.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/css/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-signin").Include("~/Content/css/bootstrap-signin.css"));

            bundles.Add(new ScriptBundle("~/js/bootstrap").Include("~/Content/js/bootstrap*"));


            //PLUGINS: bootstrap-wysiwyg
            bundles.Add(new StyleBundle("~/Plugins/css/bootstrap-wysiwyg").
                    Include
                            (
                            "~/Content/Plugins/bootstrap-wysiwyg/index.css",
                            "~/Content/Plugins/bootstrap-wysiwyg/prettify.css",
                            "~/Content/Plugins/bootstrap-wysiwyg/font-awesome.css",
                            "~/Content/Plugins/bootstrap-wysiwyg/bootstrap-responsive.min.css",
                            "~/Content/Plugins/bootstrap-wysiwyg/bootstrap-combined.no-icons.min.css" 
                            )
                    );
            bundles.Add(new ScriptBundle("~/Plugins/js/bootstrap-wysiwyg")
                .Include
                    (
                        "~/Content/Plugins/bootstrap-wysiwyg/bootstrap-wysiwyg.js",
                        "~/Content/Plugins/bootstrap-wysiwyg/prettify.js",
                        "~/Content/Plugins/bootstrap-wysiwyg/jquery.hotkeys.js"
                    )
                );


        }
    }
}