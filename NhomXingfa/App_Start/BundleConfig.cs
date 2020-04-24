using System.Web;
using System.Web.Optimization;

namespace NhomXingfa
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
                "~/js/jquery-3.4.1.min.js",
                "~/js/popper.js",
                "~/js/bootstrap.min.js",
                "~/js/stellar.js",
                "~/vendors/lightbox/simpleLightbox.min.js",
                "~/vendors/nice-select/js/jquery.nice-select.min.js",
                "~/vendors/isotope/imagesloaded.pkgd.min.js",
                "~/vendors/isotope/isotope-min.js",
                "~/vendors/owl-carousel/owl.carousel.min.js",
                "~/js/jquery.ajaxchimp.min.js",
                "~/vendors/counter-up/jquery.waypoints.min.js",
                "~/vendors/counter-up/jquery.counterup.js",
                "~/js/mail-script.js",
                      "~/js/theme.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      "~/css/bootstrap.css",
                      "~/vendors/linericon/style.css",
                      "~/css/font-awesome.min.css",
                      "~/css/themify-icons.css",
                      "~/css/flaticon.css",
                      "~/vendors/owl-carousel/owl.carousel.min.css",
                      "~/vendors/lightbox/simpleLightbox.css",
                      "~/vendors/nice-select/css/nice-select.css",
                      "~/vendors/animate-css/animate.css",
                      "~/vendors/jquery-ui/jquery-ui.css",
                      "~/css/style.css",
                      "~/css/responsive.css"));

            #region Admin
            bundles.Add(new ScriptBundle("~/Areas/bundles/jquery").Include(
                        "~/Areas/Quantri/assets/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/Areas/bundles/jqueryval").Include(
                        "~/Areas/Quantri/assets/js/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/Areas/bundles/modernizr").Include(
                        "~/Areas/Quantri/assets/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Areas/Quantri/assets/js/jquery.unobtrusive-ajax.min.js",
                      "~/Areas/Quantri/assets/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Areas/bundles/js").Include(
                      //"~/assets/js/jquery-1.10.2.min.js",
                      //"~/assets/js/jqueryui-1.10.3.min.js",
                      //"~/assets/js/bootstrap.min.js",
                      "~/Areas/Quantri/assets/js/enquire.js",
                      "~/Areas/Quantri/assets/js/jquery.cookie.js",
                      "~/Areas/Quantri/assets/js/jquery.nicescroll.min.js",
                      "~/Areas/Quantri/assets/plugins/codeprettifier/prettify.js",
                      "~/Areas/Quantri/assets/plugins/easypiechart/jquery.easypiechart.min.js",
                      "~/Areas/Quantri/assets/plugins/sparklines/jquery.sparklines.min.js",
                      "~/Areas/Quantri/assets/plugins/form-toggle/toggle.min.js",
                      "~/Areas/Quantri/assets/plugins/form-nestable/jquery.nestable.min.js",
                      "~/Areas/Quantri/assets/demo/demo-nestable.js",
                      "~/Areas/Quantri/assets/plugins/fullcalendar/fullcalendar.min.js",
                      "~/Areas/Quantri/assets/plugins/form-daterangepicker/daterangepicker.min.js",
                      "~/Areas/Quantri/assets/plugins/form-daterangepicker/moment.min.js",
                      "~/Areas/Quantri/assets/plugins/charts-flot/jquery.flot.min.js",
                      "~/Areas/Quantri/assets/plugins/charts-flot/jquery.flot.resize.min.js",
                      "~/Areas/Quantri/assets/plugins/charts-flot/jquery.flot.orderBars.min.js",
                      "~/Areas/Quantri/assets/plugins/pulsate/jQuery.pulsate.min.js",
                      "~/Areas/Quantri/assets/js/jquery.unobtrusive-ajax.min.js",
                      //"~/assets/demo/demo-index.js",
                      "~/Areas/Quantri/assets/js/placeholdr.js",
                      "~/Areas/Quantri/assets/js/application.js",
                      "~/Areas/Quantri/assets/demo/demo.js",
                        "~/Areas/Quantri/assets/js/client.js"
                      ));

            bundles.Add(new StyleBundle("~/Areas/Content/css").Include(
                "~/Areas/Quantri/assets/css/styles.minc726.css",
                      "~/Areas/Quantri/assets/demo/variations/default.css",
                      "~/Areas/Quantri/assets/plugins/fullcalendar/fullcalendar.css",
                      "~/Areas/Quantri/assets/plugins/form-markdown/css/bootstrap-markdown.min.css",
                      "~/Areas/Quantri/assets/plugins/codeprettifier/prettify.css",
                      "~/Areas/Quantri/assets/plugins/form-toggle/toggles.css",
                      "~/Areas/Quantri/assets/css/CustomsStyle.css"));


            bundles.Add(new StyleBundle("~/Areas/Content/bundleupload").Include(
                "~/Areas/Quantri/assets/css/jQuery.FileUpload/css/jquery.fileupload.css",
               "~/Areas/Quantri/assets/css/jQuery.FileUpload/css/jquery.fileupload-ui.css",
               "~/Areas/Quantri/assets/css/blueimp-gallery2/css/blueimp-gallery.css",
                 "~/Areas/Quantri/assets/css/blueimp-gallery2/css/blueimp-gallery-video.css",
                   "~/Areas/Quantri/assets/css/blueimp-gallery2/css/blueimp-gallery-indicator.css"
               ));

            bundles.Add(new ScriptBundle("~/Areas/bundles/bundleupload").Include(
                     //<!-- The Templates plugin is included to render the upload/download listings -->
                     "~/Areas/Quantri/assets/js/jQuery.FileUpload/vendor/jquery.ui.widget.js",
                       "~/Areas/Quantri/assets/js/jQuery.FileUpload/tmpl.min.js",
                    //<!-- The Load Image plugin is included for the preview images and image resizing functionality -->
                    "~/Areas/Quantri/assets/js/jQuery.FileUpload/load-image.all.min.js",
                    //<!-- The Canvas to Blob plugin is included for image resizing functionality -->
                    "~/Areas/Quantri/assets/js/jQuery.FileUpload/canvas-to-blob.min.js",
                    //"~/Scripts/file-upload/jquery.blueimp-gallery.min.js",
                    //<!-- The Iframe Transport is required for browsers without support for XHR file uploads -->
                    "~/Areas/Quantri/assets/js/jQuery.FileUpload/jquery.iframe-transport.js",
                    //<!-- The basic File Upload plugin -->
                    "~/Areas/Quantri/assets/js/jQuery.FileUpload/jquery.fileupload.js",
                    //<!-- The File Upload processing plugin -->
                    "~/Areas/Quantri/assets/js/jQuery.FileUpload/jquery.fileupload-process.js",
                    //<!-- The File Upload image preview & resize plugin -->
                    "~/Areas/Quantri/assets/js/jQuery.FileUpload/jquery.fileupload-image.js",
                    //<!-- The File Upload audio preview plugin -->
                    "~/Areas/Quantri/assets/js/jQuery.FileUpload/jquery.fileupload-audio.js",
                    //<!-- The File Upload video preview plugin -->
                    "~/Areas/Quantri/assets/js/jQuery.FileUpload/jquery.fileupload-video.js",
                    //<!-- The File Upload validation plugin -->
                    "~/Areas/Quantri/assets/js/jQuery.FileUpload/jquery.fileupload-validate.js",
                    //!-- The File Upload user interface plugin -->
                    "~/Areas/Quantri/assets/js/jQuery.FileUpload/jquery.fileupload-ui.js",
                    //Blueimp Gallery 2 
                    "~/Areas/Quantri/assets/js/blueimp-gallery2/js/blueimp-gallery.js",
                    "~/Areas/Quantri/assets/js/blueimp-gallery2/js/blueimp-gallery-video.js",
                    "~/Areas/Quantri/assets/js/blueimp-gallery2/js/blueimp-gallery-indicator.js",
                    "~/Areas/Quantri/assets/js/blueimp-gallery2/js/jquery.blueimp-gallery.js"

                ));


            bundles.Add(new ScriptBundle("~/Areas/bundles/Blueimp-Gallerry2").Include(//Blueimp Gallery 2 
                                        "~/Areas/Quantri/assets/js/blueimp-gallery2/js/blueimp-gallery.js",
                                        "~/Areas/Quantri/assets/js/blueimp-gallery2/js/blueimp-gallery-video.js",
                                        "~/Areas/Quantri/assets/js/blueimp-gallery2/js/blueimp-gallery-indicator.js",
                                        "~/Areas/Quantri/assets/js/blueimp-gallery2/js/jquery.blueimp-gallery.js"));
            #endregion

        }
    }
}
