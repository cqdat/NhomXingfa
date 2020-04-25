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
            model.lstServices = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs_more && b.IsActive == true && b.BlogID != 3).ToList();
            model.lstProductNoibat = db.ProductGroups.Where(a => a.GroupCode == WebConstants.ProductNoiBat).Take(8).ToList();
            model.lstListProjects = db.Products.Where(p => p.IsActive == true && p.IsProduct == false && p.ProductCode == "BST").OrderByDescending(p=>p.ProductID).Take(8).ToList();
            model.lstLastNews = db.Blogs.Where(q => q.IsActive == true && q.TypeBlog == WebConstants.BlogNews).OrderByDescending(q=>q.LastModify).Take(3).ToList();
            return View(model);
        }

        #region 
        /// <summary>
        /// Menu
        /// </summary>
        /// <returns></returns>
        public PartialViewResult loadMenu()
        {
            //var model = db.MENUs.Where(q => q.IdCha == 0).OrderBy(o => o.ThuTu);

            MenuViewModel model = new MenuViewModel();
            model.Phone = db.Information.Where(c => c.InfoCode== "Phone").FirstOrDefault();
            model.Email = db.Information.Where(c => c.InfoCode == "Email").FirstOrDefault();
            model.lstProductCategory = db.Categories.Where(c => c.DisplayMenu == true && c.IsActive == true && c.TypeCate == WebConstants.CategoryProduct).ToList();
            model.lstNewsCategory = db.Categories.Where(c => c.IsActive == true && c.TypeCate == WebConstants.CategoryNews).ToList();
            
            var gt = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs_more && b.BlogID == 3 && b.IsActive == true).FirstOrDefault();
            ViewBag.URLGioiThieu = gt.SEOUrlRewrite + "-" + gt.BlogID;
            return PartialView("_headMenu", model);
        }

        public PartialViewResult loadFooter()
        {
            //var model = db.MENUs.Where(q => q.IdCha == 0).OrderBy(o => o.ThuTu);

            FooterViewModel model = new FooterViewModel();
            model.lstInformation = db.Information.Take(3).ToList();
            model.lstNewsCategory = db.Categories.Where(c => c.IsActive == true && c.TypeCate == WebConstants.CategoryNews).ToList();
            return PartialView("_footer", model);
        }
        #endregion

        public ActionResult About(int? id)
        {
            if (id == null)
            {
                return View("NotFound", "Home");
            }
            AboutUsViewModel model = new AboutUsViewModel();
            model.aboutus = db.Blogs.Where(b => b.IsActive == true && b.BlogID == id && (b.TypeBlog == WebConstants.BlogAboutUs || b.TypeBlog == WebConstants.BlogAboutUs_more)).FirstOrDefault();
            model.lstAboutMoreLeftMenu = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs || b.TypeBlog == WebConstants.BlogAboutUs_more && b.BlogID != id).OrderBy(c => c.Sort).ToList();
            model.lstCategory = db.Categories.Where(c => c.IsActive == true && c.TypeCate == WebConstants.CategoryProduct).ToList();
            model.lstLastNews = db.Blogs.Where(q => q.IsActive == true && q.TypeBlog == WebConstants.BlogNews).OrderByDescending(q => q.LastModify).Take(5).ToList();
            ViewBag.Title = db.Blogs.Where(b => b.TypeBlog == WebConstants.BlogAboutUs_more && b.BlogID == 3 && b.IsActive == true).FirstOrDefault().BlogName;
            //ViewBag.URLGioiThieu = gt.SEOUrlRewrite + "-" + gt.BlogID;
            return View(model);
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