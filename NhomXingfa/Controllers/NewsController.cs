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

            model.categories = db.Categories.Where(q => q.IsActive == true && q.TypeCate == 3).ToList();

            model.category = db.Categories.Find(id);

            if (id == null)
            {
                model.blogs = db.Blogs.Where(q => q.IsActive == true).ToList();

                //model.recent = db.Blogs.Where(q => q.IsActive == true).ToList();
            }            
            else
            {
                model.blogs = db.Blogs.Where(q => q.IsActive == true && q.CategoryID == id).ToList();
                //model.recent = db.Blogs.Where(q => q.IsActive == true && q.CategoryID == id &&).ToList();
            }
            //System.Globalization.CultureInfo
            return View(model);
        }

        public ActionResult Detail(int? id)
        {
            var model = new DetailNewsViewModel();

            model.blog = db.Blogs.Find(id);
            model.category = db.Categories.Find(model.blog.CategoryID);
            model.categories = db.Categories.Where(q => q.TypeCate == 3).ToList();
            model.recents = db.Blogs.Where(q => q.CategoryID == model.blog.CategoryID && q.IsActive == true && q.CategoryID != id).ToList();

            return View(model);
        }
    }
}