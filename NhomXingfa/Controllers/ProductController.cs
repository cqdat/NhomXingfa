using NhomXingfa.Areas.Quantri.Models.DataModels;
using NhomXingfa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhomXingfa.Controllers
{
    public class ProductController : Controller
    {
        XingFaEntities db = new XingFaEntities();
        // GET: Product
        public ActionResult Index(int? id)
        {
            ProductViewModel model = new ProductViewModel();

            model.categories = db.Categories.Where(q => q.IsActive == true).ToList();

            model.category = db.Categories.Find(id);

            if (model.category.Parent == 0)
            {
                model.product = db.Products.Where(q => q.IsActive == true && q.IsProduct == true && q.CategoryIDParent == id).ToList();
            }
            else
            {
                model.product = db.Products.Where(q => q.IsActive == true && q.IsProduct == true && q.CategoryID == id).ToList();
            }
            return View(model);
        }

        public ActionResult Detail(int? id)
        {
            return View();
        }
    }
}