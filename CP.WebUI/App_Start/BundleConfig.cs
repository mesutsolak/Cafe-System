using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CP.WebUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/js")
             .Include("~/Content/template/js/scripts.js",
                      "~/Content/js/all.min.js",
                      "~/Content/js/jquery.js",
                      "~/Content/js/popper.js",
                      "~/Content/js/boostrap.js",
                      "~/Content/js/sweetalert2.js",
                      "~/Content/js/jquery.validate.js",
                      "~/Content/js/jquery-cookie.js",
                      "~/Content/js/jquery.validate.unobtrusive.js",
                      "~/Content/js/jquery.unobtrusive-ajax.js",
                      "~/Content/js/main.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/ckeditor")
                .Include("~/Content/framework/ckeditor/ckeditor.js",
                "~/Content/framework/DataTable/js/jquery.dataTables.min.js",
                "~/Content/framework/DataTable/js/dataTables.bootstrap4.min.js",
                "~/Content/js/Pagejs/Meal.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/datatable")
            .Include("~/Content/framework/DataTable/css/dataTables.bootstrap4.min.css"
                    ));



            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/Content/template/css/styles.css",
                "~/Content/css/main.css"
                        ));





        }
    }
}