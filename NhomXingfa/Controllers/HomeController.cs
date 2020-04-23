using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhomXingfa.Areas.Quantri.Models.DataModels;
using NhomXingfa.Models;
using NhomXingfa.Areas.Quantri.Utilities;

namespace NhomXingfa.Controllers
{
    public class HomeController : Controller
    {
        XingFaEntities db = new XingFaEntities();
        public ActionResult Index()
        {
            IndexViewModels model = new IndexViewModels();
            model.lstHomeBanner = db.Slides.Where(a => a.CategoryID == 0).ToList();
            model.blogGioiThieu = db.Blogs.Where(a => a.BlogID == 3).FirstOrDefault();
            model.lstProductNoibat = db.ProductGroups.Where(a => a.GroupCode == WebConstants.ProductNoiBat).ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TintucTest()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}