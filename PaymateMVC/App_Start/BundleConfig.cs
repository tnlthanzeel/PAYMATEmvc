using System.Web;
using System.Web.Optimization;

namespace PaymateMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region portfolio

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        //"~/Scripts/jquery-{version}.js",
                        "~/Assets/home/vendor/jquery/jquery.min.js",
                        "~/Assets/home/vendor/popper/popper.min.js",
                        "~/Assets/home/vendor/jquery-easing/jquery.easing.min.js"

                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                     "~/Assets/home/vendor/bootstrap/js/bootstrap.min.js",
                     "~/Assets/home/js/grayscale.min.js"

                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Assets/home/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Assets/home/vendor/font-awesome/css/font-awesome.min.css",
                      "~/Assets/home/css/grayscale.min.css"
                      ));

            #endregion

            #region Login

            bundles.Add(new StyleBundle("~/Login/css").Include(
                "~/Assets/vendor/bootstrap/css/bootstrap.min.css",
                "~/Assets/vendor/font-awesome/css/font-awesome.min.css",
                "~/Assets/css/sb-admin.css"
                ));

            bundles.Add(new ScriptBundle("~/Login/js").Include(
                "~/Assets/vendor/jquery/jquery.min.js",
                "~/Assets/vendor/popper/popper.min.js",
                "~/Assets/vendor/bootstrap/js/bootstrap.min.js",
                "~/Assets/vendor/jquery-easing/jquery.easing.min.js"
                ));


            #endregion



            #region login error message

            bundles.Add(new StyleBundle("~/toastr/css").Include(
            "~/Content/site.css",
            "~/Content/toastr.css"
            ));

            bundles.Add(new ScriptBundle("~/Bundles/toastr").Include(
                "~/Scripts/toastr.js*",
                "~/Scripts/toastrImp.js"
                ));


            #endregion



            #region Dashboard

            bundles.Add(new StyleBundle("~/Dashboard/css").Include(
                "~/Assets/vendor/bootstrap/css/bootstrap.min.css",
                "~/Assets/vendor/font-awesome/css/font-awesome.min.css",
                "~/Assets/vendor/datatables/dataTables.bootstrap4.css",
                "~/Assets/css/sb-admin.css"
                ));


            bundles.Add(new ScriptBundle("~/Dashboard/js").Include(
                "~/Assets/vendor/jquery/jquery.min.js",
                "~/Assets/vendor/popper/popper.min.js",
                "~/Assets/vendor/bootstrap/js/bootstrap.min.js",
                "~/Assets/vendor/jquery-easing/jquery.easing.min.js",
                "~/Assets/vendor/chart.js/Chart.min.js",
                "~/Assets/vendor/datatables/jquery.dataTables.js",
                "~/Assets/vendor/datatables/dataTables.bootstrap4.js",
                "~/Assets/js/sb-admin.min.js",
                "~/Assets/js/sb-admin-datatables.min.js",
                "~/Assets/js/sb-admin-charts.min.js"
                ));
            #endregion


            #region calander



            #endregion

            #region datetimepicker
            bundles.Add(new StyleBundle("~/datetimepicker/css").Include(
                "~/Content/themes/base/jquery-ui.min.css"
                ));
            #endregion
        }


    }
}
