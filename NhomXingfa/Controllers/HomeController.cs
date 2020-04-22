using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NhomXingfa.Areas.Quantri.Models.DataModels;
using NhomXingfa.Models;

namespace NhomXingfa.Controllers
{
    public class HomeController : Controller
    {
        XingFaEntities db = new XingFaEntities();
        public ActionResult Index()
        {
            IndexViewModels model = new IndexViewModels();
            model.lstHomeBanner = db.Slides.Where(a => a.CategoryID == 0).ToList();
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
    }
}