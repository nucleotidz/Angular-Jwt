﻿using System.Web;
using System.Web.Optimization;

namespace JWT.Security
{
    public class BundleConfig
    {
        // Bundle Config
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Jquery/js").Include(
                      "~/Scripts/Jquery/jquery-1.10.2.js",
                      "~/Scripts/Jquery/jquery.signalR-2.1.2.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Angular/js").Include
                (
                  "~/Scripts/Angular/angular.min.js",
                 "~/Scripts/Angular/angular-resource.min.js",
                 "~/Scripts/Angular/angular-ui-router.js",
                  "~/Scripts/Angular/app.js",
                  "~/Scripts/Angular/route.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/Controller/js").Include
                  (
                    "~/Scripts/Controller/HomeController.js"          
                  ));
            bundles.Add(new ScriptBundle("~/Scripts/Factory/js").Include
                    (
                      "~/Scripts/Factory/API.js"   ,
                        "~/Scripts/Factory/Interceptor.js"  
                    ));
        }
    }
}
