using System.Web;
using System.Web.Optimization;

namespace ISBank_Assessment.UI
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

            bundles.Add(new ScriptBundle("~/bundles/jqueryUI").Include(
                        "~/Scripts/jquery-ui.js" ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive-ajax*"));

            bundles.Add(new ScriptBundle("~/bundles/user").Include(
                        "~/Scripts/User_/ProductSlider.js",
                        "~/Scripts/User_/ErrorHandler.js",
                        "~/Scripts/User_/global.js",
                        "~/Scripts/User_/DataTables.js",
                        "~/Scripts/User_/Select2.js",
                        "~/Scripts/User_/DatePicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                 "~/Scripts/Plugins/datatables/media/js/jquery.dataTables.js"
                , "~/Scripts/Plugins/datatables/media/js/dataTables.bootstrap4.js"
                , "~/Scripts/Plugins/datatables/media/js/dataTables.responsive.js"
                , "~/Scripts/Plugins/datatables/media/js/responsive.bootstrap4.js"
                , "~/Scripts/Plugins/datatables/media/js/button/datatables.buttons.js"
                , "~/Scripts/Plugins/datatables/media/js/button/buttons.bootstrap4.js"
                , "~/Scripts/Plugins/datatables/media/js/button/buttons.print.js"
                , "~/Scripts/Plugins/datatables/media/js/button/buttons.html5.js"
                , "~/Scripts/Plugins/datatables/media/js/button/buttons.flash.js"
                , "~/Scripts/Plugins/datatables/media/js/button/pdfmake.min.js"
                , "~/Scripts/Plugins/datatables/media/js/button/vfs_fonts.js"
                ));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));



            //Styl driectly from plugins and theme
            bundles.Add(new StyleBundle("~/Content/stylecss").Include(
                    "~/Content/Style/css_/style.css",
                    "~/Content/Style/css_/bootstrap-datepicker.css",
                    //"~/Content/nice-select.css",
                    "~/Content/all.css",
                    "~/Content/bootstrap.min.css",
                    "~/Content/jquery.steps.css",
                    "~/Content/fontawesome-all.css",
                    "~/Content/css/jAlert.css",
                    "~/Content/css/jquery-confirm.min.css",
                    "~/Content/bootstrap-toggle.min.css",
                    "~/Content/Gijgo/combined/gijgo.css",
                    "~/Content/css/select2.css",
                    "~/Content/pageguide.css",
                    "~/Content/ej2/material.css"
            ));


            bundles.Add(new StyleBundle("~/Content/datatablesstyles").Include(
                   "~/Scripts/Plugins/datatables/media/css/jquery.dataTables.css"
                  , "~/Scripts/Plugins/datatables/media/css/dataTables.bootstrap4.css"
                  , "~/Scripts/Plugins/datatables/media/css/responsive.dataTables.css"
            ));

            bundles.Add(new StyleBundle("~/Content/datatablesstyles").Include(
                   "~/Scripts/Plugins/datatables/media/css/jquery.dataTables.css"
                  , "~/Scripts/Plugins/datatables/media/css/dataTables.bootstrap4.css"
                  , "~/Scripts/Plugins/datatables/media/css/responsive.dataTables.css"
            ));

            bundles.Add(new StyleBundle("~/Content/jqueryUI").Include(
                    "~/Content/jquery-ui.css"
           ));

        }
    }
}
