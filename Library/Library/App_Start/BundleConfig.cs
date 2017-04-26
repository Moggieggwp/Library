using System.Web;
using System.Web.Optimization;

namespace Library
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap.min.css",
                "~/Content/site.css",
                "~/Content/angular-busy.css",
                "~/Content/toaster.css",
                "~/Content/bootstrap-datepicker.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/libs/jquery-{version}.js"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство построения на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/libs/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/libs/bootstrap.js",
                      "~/Scripts/libs/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      //"~/Scripts/css/bootstrap.css",
                      "~/Scripts/css/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/libs/angular/angular.js")
                .Include("~/Scripts/libs/angular/angular-busy.js")
                .Include("~/Scripts/libs/angular/toaster.js")
                .Include("~/Scripts/libs/angular/angular-animate.js"));

            bundles.Add(new ScriptBundle("~/bundles/Library")
                .Include("~/Scripts/apps/Library.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts")
                .Include("~/Scripts/apps/controllers/*.js")
                .Include("~/Scripts/apps/services/*.js"));
        }
    }
}
