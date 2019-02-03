using System.Web;
using System.Web.Optimization;

namespace MalweeCodeChallenge
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
       public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(


                    //jQuery
                    "~/Content/assets/js/jquery.min.js",
                    "~/Content/assets/js/bootstrap.min.js",
                    "~/Content/assets/js/detect.js",
                    "~/Content/assets/js/fastclick.js",
                    "~/Content/assets/js/jquery.blockUI.js",
                    "~/Content/assets/js/waves.js",
                    "~/Content/assets/js/jquery.slimscroll.js",
                    "~/Content/assets/js/jquery.scrollTo.min.js",
                    "~/Content/plugins/switchery/switchery.min.js",
                    "~/Content/plugins/switchery/switchery.min.js",

                    //Counter js
                    "~/Content/plugins/waypoints/jquery.waypoints.min.js",
                    "~/Content/plugins/counterup/jquery.counterup.min.js",

                    //Morris Chart
                    "~/Content/plugins/morris/morris.min.js",
                    "~/Content/plugins/raphael/raphael-min.js",

                    //Dashboard init
                    "~/Content/assets/pages/jquery.dashboard.js",

                    //App js
                    "~/Content/assets/js/jquery.core.js",
                    "~/Content/assets/js/jquery.app.js",

                    //Pickers
                    "~/Content/plugins/moment/moment.js",
                    "~/Content/plugins/timepicker/bootstrap-timepicker.js",
                    "~/Content/plugins/bootstrap-colorpicker/js/bootstrap-colorpicker.min.js",
                    "~/Content/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js",
                    "~/Content/plugins/clockpicker/js/bootstrap-clockpicker.min.js",
                    "~/Content/plugins/bootstrap-daterangepicker/daterangepicker.js",

                    //Select2
                    "~/Content/plugins/bootstrap-tagsinput/js/bootstrap-tagsinput.min.js",
                    "~/Content/plugins/multiselect/js/jquery.multi-select.js",
                    "~/Content/plugins/jquery-quicksearch/jquery.quicksearch.js",
                    "~/Content/plugins/select2/js/select2.min.js",
                    "~/Content/plugins/bootstrap-select/js/bootstrap-select.min.js",
                    "~/Content/plugins/bootstrap-filestyle/js/bootstrap-filestyle.min.js",
                    "~/Content/plugins/bootstrap-touchspin/js/jquery.bootstrap-touchspin.min.js",
                    "~/Content/plugins/bootstrap-maxlength/bootstrap-maxlength.min.js",
                    "~/Content/plugins/autocomplete/countries.js",
                    "~/Content/assets/pages/jquery.form-advanced.init.js",

                    //DataTable
                    "~/Content/plugins/datatables/jquery.dataTables.min.js",
                    "~/Content/plugins/datatables/dataTables.bootstrap.js",
                    "~/Content/plugins/datatables/dataTables.buttons.min.js",
                    "~/Content/plugins/datatables/buttons.bootstrap.min.js",
                    "~/Content/plugins/datatables/jszip.min.js",
                    "~/Content/plugins/datatables/pdfmake.min.js",
                    "~/Content/plugins/datatables/vfs_fonts.js",
                    "~/Content/plugins/datatables/buttons.html5.min.js",
                    "~/Content/plugins/datatables/buttons.print.min.js",
                    "~/Content/plugins/datatables/dataTables.fixedHeader.min.js",
                    "~/Content/plugins/datatables/dataTables.keyTable.min.js",
                    "~/Content/plugins/datatables/dataTables.responsive.min.js",
                    "~/Content/plugins/datatables/responsive.bootstrap.min.js",
                    "~/Content/plugins/datatables/dataTables.scroller.min.js",
                    "~/Content/plugins/datatables/dataTables.colVis.js",
                    "~/Content/plugins/datatables/dataTables.fixedColumns.min.js",
                    "~/Content/assets/pages/jquery.datatables.init.js",

                    //Notificação
                    "~/Scripts/sweetalert.min.js",

                    //Init js
                    "~/Content/assets/pages/jquery.form-pickers.init.js"
                    ));

            bundles.Add(new StyleBundle("~/Content/css").Include(

                    //Select2
                    "~/Content/plugins/bootstrap-tagsinput/css/bootstrap-tagsinput.css",
                    "~/Content/plugins/multiselect/css/multi-select.css",
                    "~/Content/plugins/select2/css/select2.min.css",
                    "~/Content/plugins/bootstrap-select/css/bootstrap-select.min.css",
                    "~/Content/plugins/bootstrap-touchspin/css/jquery.bootstrap-touchspin.min.css",

                    //Pickers
                    "~/Content/plugins/timepicker/bootstrap-timepicker.min.css",
                    "~/Content/plugins/bootstrap-colorpicker/css/bootstrap-colorpicker.min.css",
                    "~/Content/plugins/bootstrap-datepicker/css/bootstrap-datepicker.min.css",
                    "~/Content/plugins/clockpicker/css/bootstrap-clockpicker.min.css",
                    "~/Content/plugins/bootstrap-daterangepicker/daterangepicker.css",

                    //DataTable
                    "~/Content/plugins/datatables/jquery.dataTables.min.css",
                    "~/Content/plugins/datatables/buttons.bootstrap.min.css",
                    "~/Content/plugins/datatables/fixedHeader.bootstrap.min.css",
                    "~/Content/plugins/datatables/responsive.bootstrap.min.css",
                    "~/Content/plugins/datatables/scroller.bootstrap.min.css",
                    "~/Content/plugins/datatables/dataTables.colVis.css",
                    "~/Content/plugins/datatables/dataTables.bootstrap.min.css",
                    "~/Content/plugins/datatables/fixedColumns.dataTables.min.css",

                    //Morris Chart
                    "~/Content/plugins/morris/morris.css",

                    //Notificação
                    "~/Content/toastr.css",

                    //App css
                    "~/Content/assets/css/bootstrap.min.css",
                    "~/Content/assets/css/core.css",
                    "~/Content/assets/css/components.css",
                    "~/Content/assets/css/icons.css",
                    "~/Content/assets/css/pages.css",
                    "~/Content/assets/css/menu.css",
                    "~/Content/assets/css/responsive.css",
                    "~/Content/plugins/switchery/switchery.min.css"
                    ));
        }
    }
}
