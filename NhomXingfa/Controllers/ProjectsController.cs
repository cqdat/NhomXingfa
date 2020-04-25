using NhomXingfa.Areas.Quantri.Models.DataModels;
using NhomXingfa.Areas.Quantri.Utilities;
using NhomXingfa.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            model.lstCategory = db.Categories.Where(c => c.IsActive == true && c.TypeCate == WebConstants.CategoryProduct).ToList();
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

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("NotFound", "Home");
            }
            ProjectViewModel model = new ProjectViewModel();
            model.detail = db.Products.Where(p => p.IsActive == true && p.IsProduct == false && p.ProductID == id).FirstOrDefault();
            model.detail.CountView = model.detail.CountView + 1;
            db.Entry(model.detail).State = EntityState.Modified;
            db.SaveChanges();
            model.lstCategory= db.Categories.Where(c => c.IsActive == true && c.TypeCate == WebConstants.CategoryProduct).ToList();
            model.lstImages = db.ProductImages.Where(i => i.ProductID == id).ToList();
            var cateid = db.Products.Where(p => p.IsActive == true && p.IsProduct == false && p.ProductID == id).FirstOrDefault().CategoryID;
            model.lstProjects1 = db.Products.Where(p => p.IsActive == true && p.IsProduct == false && p.CategoryID == cateid && p.ProductID != id).OrderByDescending(p => p.ProductID).Take(4).ToList();


            return View(model);
        }
    }
}