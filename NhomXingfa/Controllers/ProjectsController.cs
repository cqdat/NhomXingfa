using NhomXingfa.Areas.Quantri.Models.DataModels;
using NhomXingfa.Areas.Quantri.Utilities;
using NhomXingfa.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhomXingfa.Controllers
{
    public class ProjectsController : Controller
    {
        XingFaEntities db = new XingFaEntities();
        // GET: Projects
        public ActionResult Index()
        {
            ProjectViewModel model = new ProjectViewModel();
            model.lstCatetory= db.Categories.Where(c => c.IsActive == true && c.TypeCate == WebConstants.CategoryProduct).ToList();
            model.lstNews= db.Blogs.Where(q => q.IsActive == true && q.TypeBlog == WebConstants.BlogNews).OrderByDescending(q => q.LastModify).Take(5).ToList();
            return View(model);
        }

        public ActionResult _partialIndex(int? pageNumber, int? pageSize)
        {

            if (pageSize == -1)
            {
                pageSize = db.Products.Where(b => b.IsProduct == false && b.IsActive == true && b.ProductCode == "BST").ToList().Count;
            }
            ViewBag.PageSize = pageSize;

            var lstprod = db.Products.Where(b => b.IsProduct == false && b.IsActive == true && b.ProductCode == "BST").ToList();

            lstprod = lstprod.OrderByDescending(s => s.ProductID).ToList();

            ViewBag.STT = pageNumber * pageSize - pageSize + 1;
            int count = lstprod.ToList().Count();
            ViewBag.TotalRow = count;
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/Projects/_partialIndex.cshtml", lstprod.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 2));
            }
            return View(lstprod.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 2));
        }
    }
}