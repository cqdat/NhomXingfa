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

            if (id > 0)
            {
                model.category = db.Categories.Find(id);
                model.IsAll = false;
                //model.Title = model.category.CategoryName;
            }
            else
            {
                model.Title = "Sản phẩm";
                model.IsAll = true;
                model.product = db.Products.Where(q => q.IsActive == true).ToList();
            }


                return View(model);
        }
    }
}