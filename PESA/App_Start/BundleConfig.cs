﻿using System.Web;
using System.Web.Optimization;

namespace PESA
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
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome/font-awesome.min.css"));

                      // Header & Footer
            bundles.Add(new StyleBundle("~/assets/headerfooter").Include(
                      "~/assets/css/headers/header-v8.css",
                      "~/assets/css/footers/footer-v8.css"));

                    // CSS Theme
            bundles.Add(new StyleBundle("~/assets/theme").Include(
                    "~/assets/css/theme-colors/green.css",
                    "~/assets/css/blog.style.css",
                    "~/assets/css/theme-skins/dark.css",
                    "~/assets/css/custom.css"));

                    //  < !--CSS Implementing Plugins -->
            bundles.Add(new StyleBundle("~/assets/plugins.css").Include(
                    "~/assets/plugins/animate.css",
                    "~/assets/plugins/line-icons/line-icons.css",
                    "~/assets/plugins/fancybox/source/jquery.fancybox.css",
                    "~/assets/plugins/font-awesome/css/font-awesome.min.css",
                    "~/assets/plugins/master-slider/masterslider/style/masterslider.css",
                    "~/assets/plugins/master-slider/masterslider/skins/black-2/style.css"
                    ));

            //////////////////////////////////////////////////////////////

                    // JS Implementing Plugins
            bundles.Add(new ScriptBundle("~/assets/plugins.js").Include(
                    "~/assets/plugins/back-to-top.js",
                    "~/assets/plugins/smoothScroll.js",
                    "~/assets/plugins/counter/waypoints.min.js",
                    "~/assets/plugins/counter/jquery.counterup.min.js",
                    "~/assets/plugins/master-slider/masterslider/masterslider.js",
                    "~/assets/plugins/master-slider/masterslider/jquery.easing.min.js",
                    "~/assets/plugins/jquery.scrollbox.js"
                    ));

                    //JS Page Level
            bundles.Add(new ScriptBundle("~/assets/pagejs").Include(
                    "~/assets/js/app.js",
                    "~/assets/js/custom.js",
                    "~/assets/js/plugins/fancy-box.js",
                    "~/assets/js/plugins/owl-carousel.js",
                    "~/assets/js/plugins/master-slider-showcase4.js",
                    "~/assets/js/plugins/style-switcher.js",
                    "~/assets/js/plugins/jquery.slimscroll.min.js"
                    ));


            ////////////////// carousel ////////////////
            bundles.Add(new ScriptBundle("~/assets/plugins/owl-carousel.js").Include(
                    "~/assets/plugins/owl-carousel/owl-carousel/owl.carousel.js"
                ));
            bundles.Add(new StyleBundle("~/assets/plugins/owl-carousel.css").Include(
                    "~/assets/plugins/owl-carousel/owl-carousel/owl.carousel.css",
                    "~/assets/plugins/owl-carousel/owl-carousel/owl.theme.css"
                ));
        }
    }
}
