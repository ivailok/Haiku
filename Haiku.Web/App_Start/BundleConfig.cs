﻿using System.Web;
using System.Web.Optimization;

namespace Haiku.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-select.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-select.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome-4.5.0/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/mycss").Include(
                "~/Content/Styles/haikus.css",
                "~/Content/Styles/haikuSmall.css",
                "~/Content/Styles/user.css",
                "~/Content/Styles/haikuEdit.css",
                "~/Content/Styles/haikuWrite.css",
                "~/Content/Styles/userRegister.css",
                "~/Content/Styles/haikuDetails.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                "~/Scripts/angular-bootstrap-select.js",
                "~/Scripts/sha3.js",

                "~/Scripts/shared/services/services.js",
                "~/Scripts/shared/services/http-service.js",
                "~/Scripts/shared/services/haikus-service.js",
                "~/Scripts/shared/services/users-service.js",
                "~/Scripts/shared/services/reports-service.js",

                "~/Scripts/shared/directives/directives.js",
                "~/Scripts/shared/directives/haikuSmallInfo.js",
                "~/Scripts/shared/directives/autoHeight.js",
                "~/Scripts/shared/directives/selectPicker.js",
                "~/Scripts/shared/directives/customAutofocus.js"));
        }
    }
}
