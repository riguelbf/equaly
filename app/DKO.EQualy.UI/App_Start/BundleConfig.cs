using System.Web;
using System.Web.Optimization;

namespace DKO.EQualy.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/plugins/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/plugins/bootstrap.js",
                      "~/Scripts/plugins/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/assets").Include(
                       "~/Content/assets/css/themes/default.css",
                      "~/Content/assets/plugins/bootstrap/css/bootstrap.min.css",
                      "~/Content/assets/plugins/bootstrap/css/bootstrap-responsive.min.css",
                      "~/Content/assets/plugins/bootstrap-modal/css/bootstrap-modal.css",
                      "~/Content/assets/plugins/font-awesome/css/font-awesome.min.css",
                      "~/Content/assets/css/style-metro.css",
                      "~/Content/assets/css/style.css",
                      "~/Content/assets/css/style-responsive.css",
                      "~/Content/assets/plugins/uniform/css/uniform.default.css",
                      "~/Content/assets/plugins/gritter/css/jquery.gritter.css",
                      "~/Content/assets/plugins/bootstrap-daterangepicker/daterangepicker.css",
                      "~/Content/assets/plugins//bootstrap-datetimepicker/css/datetimepicker.css",
                      "~/Content/assets/plugins/fullcalendar/fullcalendar/fullcalendar.css",
                      "~/Content/assets/plugins/jqvmap/jqvmap/jqvmap.css",
                      "~/Content/assets/plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.css",
                      "~/Content/assets/plugins/data-tables/DT_bootstrap.css",
                      "~/Content/assets/css/pages/tasks.css",
                      "~/Content/loading.css",
                      "~/Content/assets/fonts/font.css",
                      "~/Content/assets/plugins/bootstrap-datetimepicker/css/datetimepicker.css",
                      "~/Content/assets/plugins/bootstrap-datepicker/css/datepicker.css",
                      "~/Content/assets/plugins/data-tables/dataTableToolsExport/css/dataTables.tableTools.css"
                      
                      ));

            bundles.Add(new ScriptBundle("~/bundles/assets/scripts").Include(
                //"~/Content/assets/plugins/jquery-1.10.1.min.js",
                "~/Content/assets/plugins/jquery-1.10.1.min.js",
                "~/Content/assets/plugins/jquery-migrate-1.2.1.min.js",
                "~/Content/assets/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js",
                "~/Content/assets/plugins/bootstrap/js/bootstrap.js",
                "~/Content/assets/plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js",
                "~/Content/assets/plugins/excanvas.min.js",
                "~/Content/assets/plugins/respond.min.js",
                "~/Content/assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/Content/assets/plugins/jquery.blockui.min.js",
                "~/Content/assets/plugins/jquery.cookie.min.js",
                "~/Content/assets/plugins/jquery-inputmask/jquery.inputmask.bundle.min.js",
                "~/Content/assets/plugins/uniform/jquery.uniform.min.js",
                "~/Content/assets/plugins/flot/jquery.flot.js",
                "~/Content/assets/plugins/flot/jquery.flot.resize.js",
                "~/Content/assets/plugins/jquery.pulsate.min.js",
                "~/Content/assets/plugins/bootstrap-daterangepicker/date.js",
                "~/Content/assets/plugins/bootstrap-daterangepicker/daterangepicker.js",
                "~/Content/assets/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js",
                "~/Content/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js",
                //"~/Content/assets/plugins/bootstrap-datetimepicker/js/locales/bootstrap-datetimepicker.pt-BR.js",
                "~/Content/assets/plugins/gritter/js/jquery.gritter.js",
                "~/Content/assets/plugins/fullcalendar/fullcalendar/fullcalendar.min.js",
                "~/Content/assets/plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.js",
                "~/Content/assets/plugins/jquery.sparkline.min.js",
                "~/Content/assets/scripts/tasks.js",
                "~/Content/assets/plugins/bootstrap-modal/js/bootstrap-modal.js",
                "~/Content/assets/plugins/bootstrap-modal/js/bootstrap-modalmanager.js",
                "~/Content/assets/plugins/data-tables/jquery.dataTables.js",
                "~/Content/assets/plugins/data-tables/DT_bootstrap.js",
                "~/Content/assets/plugins/data-tables/dataTableToolsExport/js/dataTables.tableTools.js",
                "~/Content/assets/plugins/data-tables/dataTablesExtensions.js",
                "~/Scripts/plugins/jquery.unobtrusive-ajax.min.js",
                //"~/Scripts/plugins/jquery.validate.unobtrusive.min.js",
                "~/Content/assets/scripts/app.js",
                "~/Scripts/utils.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/plugins/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/plugins/modernizr-*"));
        }
    }
}
