using NhomXingfa.Areas.Quantri.Models.DataModels;
using NhomXingfa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhomXingfa.Controllers
{
    public class NewsController : Controller
    {
        XingFaEntities db = new XingFaEntities();
        // GET: News
        public ActionResult Index(int? id)
        {
            NewsViewModel model = new NewsViewModel();

            model.categories = db.Categories.Where(q => q.IsActive == true).ToList();

            model.category = db.Categories.Find(id);

            if (id == null)
            {
                model.blogs = db.Blogs.Where(q => q.IsActive == true).ToList();
            }            
            else
            {
                model.blogs = db.Blogs.Where(q => q.IsActive == true && q.CategoryID == id).ToList();
            }
            return View(model);
        }
    }
}