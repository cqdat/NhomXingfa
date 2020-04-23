using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using NhomXingfa.Areas.Quantri.Models.DataModels;
using NhomXingfa.Areas.Quantri.Utilities;
using PagedList;
using NhomXingfa.Areas.Quantri.Models;

namespace NhomXingfa.Areas.Quantri.Controllers
{
    public class ProductsController : BaseController
    {
        private XingFaEntities db = new XingFaEntities();

        // GET: Products
        #region List of product

        public ActionResult Index()
        {
            ViewData["ListCateParent"] = db.Categories.Where(c => c.Parent == 0 && c.TypeCate == WebConstants.CategoryProduct).ToList();
            ViewData["ListCate"] = db.Categories.Where(c => c.Parent != 0 && c.TypeCate == WebConstants.CategoryProduct).ToList();
            return View();
        }
        public ActionResult _PartialIndex(int? pageNumber, int? pageSize, string MaSP, string SanPham, int? DanhMucCha, int? DanhMucCon,
                                          string SEOKeywords)
        {
            SanPham = SanPham ?? "";
            ViewBag.SanPham = SanPham;
            pageNumber = pageNumber ?? 1;
            pageSize = pageSize ?? 10;

            if (pageSize == -1)
            {
                pageSize = db.Products.Where(p => p.IsProduct == true).ToList().Count;
            }
            ViewBag.PageSize = pageSize;

            var lstprod = db.Products.Where(p => p.IsProduct == true).ToList();

            if (!string.IsNullOrEmpty(MaSP))
            {
                lstprod = lstprod.Where(s => s.ProductCode.ToUpper().Contains(MaSP.ToUpper())).ToList();
            }
            ViewBag.MaSP = MaSP;

            if (!string.IsNullOrEmpty(SanPham))
            {
                lstprod = lstprod.Where(s => s.ProductName.ToUpper().Contains(SanPham.ToUpper())).ToList();
            }
            ViewBag.SanPham = SanPham;

            if (!string.IsNullOrEmpty(DanhMucCha.ToString()))
            {
                lstprod = lstprod.Where(s => s.CategoryIDParent == DanhMucCha).ToList();
            }
            ViewBag.DanhMucCha = DanhMucCha;

            if (!string.IsNullOrEmpty(DanhMucCon.ToString()))
            {
                lstprod = lstprod.Where(s => s.CategoryID == DanhMucCon).ToList();
            }
            ViewBag.DanhMucCon = DanhMucCon;

            if (!string.IsNullOrEmpty(SEOKeywords))
            {
                lstprod = lstprod.Where(s => s.SEOKeywords.ToUpper().Contains(SEOKeywords.ToUpper())).ToList();
            }
            ViewBag.SEOKeywords = SEOKeywords;

            lstprod = lstprod.OrderBy(s => s.Created).ToList();
            ViewBag.STT = pageNumber * pageSize - pageSize + 1;
            int count = lstprod.ToList().Count();
            ViewBag.TotalRow = count;
            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Quantri/Views/Products/_PartialIndex.cshtml", lstprod.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 2));
            }
            return View(lstprod.ToList().ToPagedList(pageNumber ?? 1, pageSize ?? 2));
        }
        #endregion

        // GET: Quantri/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Quantri/Products/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CategoryIDParent = new SelectList(db.Categories.Where(c => c.Parent == 0 && c.TypeCate == WebConstants.CategoryProduct), "CategoryID", "CategoryName");
            ViewBag.CategoryID = new SelectList(db.Categories.Where(c => c.TypeCate == WebConstants.CategoryProduct), "CategoryID", "CategoryName");
            ViewBag.CreatedBy = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: Quantri/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ProductID,ProductCode,ProductName,Price,PriceSale,CategoryIDParent,CategoryID,Images,ImagesThumb,ShortDescription,Content,InStock,IsSale,IsNew,Rating,IsActive,CountView,Created,CreatedBy,SEOTitle,SEOUrlRewrite,SEOKeywords,SEOMetadescription")] Product product,
                                   HttpPostedFileBase HinhAnh)
        {
            if (ModelState.IsValid)
            {
                var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", "jpeg"
                };
                if (HinhAnh == null)
                {
                    product.Images = "NoImage.png";
                }
                else
                {
                    var fileName = Path.GetFileName(HinhAnh.FileName);

                    var ext = Path.GetExtension(HinhAnh.FileName);
                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                        string myfile = name + "_" + DateTime.Now.Millisecond + ext; //appending the name with id  
                                                                                     // store the file inside ~/project folder(Img)  

                        var path = Path.Combine(Server.MapPath(WebConstants.ImgProduct), myfile);
                        //var dir = Directory.CreateDirectory(path);
                        //HinhAnh.SaveAs(Path.Combine(path, myfile));

                        product.Images = myfile;
                        HinhAnh.SaveAs(path);

                        product.ImagesThumb = CreateThumb(myfile);
                    }
                    else
                    {
                        ViewBag.message = "Please choose only Image file";
                    }
                }
                product.CategoryIDParent = product.CategoryID;
                product.IsProduct = true;
                
                product.PriceSale = "0";
                product.SEOUrlRewrite = Helpers.ConvertToUpperLower(product.ProductName);
                product.Created = DateTime.Now;
                product.CreatedBy = db.Users.FirstOrDefault(q => q.UserName == User.Identity.Name).UserID;
                //product.CreatedBy = 1;
                db.Products.Add(product);
                db.SaveChanges();
                Success(string.Format("Thêm mới sản phẩm<b>{0}</b> thành công.", product.ProductName), true);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryIDParent = new SelectList(db.Categories.Where(c => c.Parent == 0), "CategoryID", "CategoryName", product.CategoryIDParent);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.CreatedBy = new SelectList(db.Users, "UserID", "UserName", product.CreatedBy);
            Success(string.Format("Thêm mới sản phẩm<b>{0}</b> thành công.", product.ProductName), true);
            //return RedirectToAction("Index");
            return View(product);
        }

        // GET: Quantri/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryIDParent = new SelectList(db.Categories.Where(c => c.Parent == 0 && c.TypeCate == WebConstants.CategoryProduct), "CategoryID", "CategoryName", product.CategoryIDParent);
            ViewBag.CategoryID = new SelectList(db.Categories.Where(c => c.Parent == product.CategoryIDParent && c.TypeCate == WebConstants.CategoryProduct), "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.CreatedBy = new SelectList(db.Users, "UserID", "UserName", product.CreatedBy);
            return View(product);
        }

        // POST: Quantri/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductCode,ProductName,IsProduct,Price,PriceSale,CategoryIDParent,CategoryID,Images,ImagesThumb,ShortDescription,Content,InStock,IsSale,IsNew,Rating,IsActive,CountView,Created,CreatedBy,SEOTitle,SEOUrlRewrite,SEOKeywords,SEOMetadescription")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryIDParent = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryIDParent);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.CreatedBy = new SelectList(db.Users, "UserID", "UserName", product.CreatedBy);
            return View(product);
        }

        // GET: Quantri/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Quantri/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public string CreateThumb(string myfile)
        {

            string pathOnServer = Path.Combine(Server.MapPath(WebConstants.ImgProduct));

            var fullPath = Path.Combine(pathOnServer, Path.GetFileName(myfile));
            string URLthumb = "";
            string fileThumb = "";
            var ThumbfullPath = Path.Combine(pathOnServer, "_thumbs");
            fileThumb = DateTime.Now.ToString("HHmmss") + "_" + myfile.Remove(myfile.Length - 4, 4) + ".80x80.jpg";
            var ThumbfullPath2 = Path.Combine(ThumbfullPath, fileThumb);
            using (MemoryStream stream = new MemoryStream(System.IO.File.ReadAllBytes(fullPath)))
            {
                var thumbnail = new WebImage(stream).Resize(200, 200);
                thumbnail.Save(ThumbfullPath2, "jpg");
                URLthumb = ThumbfullPath2;
            }

            return fileThumb;
        }


        //Get group products
        public PartialViewResult GetGroupProduct(int? productid)
        {
            GroupCheck model = new GroupCheck();

            model = GroupCheck(productid);

            return PartialView("~/Areas/Quantri/Views/Products/_group.cshtml", model);
        }
        public GroupCheck GroupCheck(int? productid)
        {
            GroupCheck model = new GroupCheck();

            var x = db.ProductGroups.Where(q => q.ProductID == productid).ToList();

            List<GroupProduct> allows = new List<GroupProduct>();
            List<GroupProduct> available = new List<GroupProduct>();

            var y = x.FirstOrDefault(q => q.GroupCode == WebConstants.ProductMoi); // mới nhất

            GroupProduct g1 = new GroupProduct();
            g1.Title = "Sản Phẩm Mới Nhất";
            g1.GroupID = 0;
            g1.IsGroup = 1;

            if (y != null)
            {
                g1.GroupID = y.ProductGroupID;

                allows.Add(g1);
            }
            else
            {
                available.Add(g1);
            }

            var y2 = x.FirstOrDefault(q => q.GroupCode == WebConstants.ProductDangKM); /// khuyến mãi

            GroupProduct g2 = new GroupProduct();
            g2.Title = "Sản Phẩm Đang Khuyến Mãi";
            g2.GroupID = 0;
            g2.IsGroup = 2;

            if (y2 != null)
            {
                g2.GroupID = y2.ProductGroupID;

                allows.Add(g2);
            }
            else
            {
                available.Add(g2);
            }

            var y3 = x.FirstOrDefault(q => q.GroupCode == WebConstants.ProductNoiBat); //nổi bật

            GroupProduct g3 = new GroupProduct();
            g3.Title = "Sản Phẩm Nổi Bật";
            g3.GroupID = 0;
            g3.IsGroup = 3;

            if (y3 != null)
            {
                g3.GroupID = y3.ProductGroupID;

                allows.Add(g3);
            }
            else
            {
                available.Add(g3);
            }

            var y4 = x.FirstOrDefault(q => q.GroupCode == WebConstants.ProductBanChay); /// bán chạy

            GroupProduct g4 = new GroupProduct();
            g4.Title = "Sản Phẩm Bán Chạy";
            g4.GroupID = 0;
            g4.IsGroup = 4;
            if (y4 != null)
            {
                g4.GroupID = y4.ProductGroupID;

                allows.Add(g4);
            }
            else
            {
                available.Add(g4);
            }

            model.allows = allows;
            model.available = available;


            return model;
        }

        //Thêm xóa Product Group
        public PartialViewResult SaveGroupProduct(int? groupid, int? productid, int? xaction, int? groupcode)
        {
            if (xaction == 0) // xóa
            {
                var gr = db.ProductGroups.Find(groupid);

                db.ProductGroups.Remove(gr);

                db.SaveChanges();
            }
            else // thêm
            {
                var gr = new ProductGroup();
                gr.GroupCode = groupcode;
                gr.ProductID = productid;
                gr.Sort = 1;

                db.ProductGroups.Add(gr);

                db.SaveChanges();
            }


            GroupCheck model = new GroupCheck();

            model = GroupCheck(productid);

            return PartialView("~/Areas/Quantri/Views/Products/_group.cshtml", model);
        }

        public JsonResult XoaGroupProduct(int? groupid)
        {
            string result = "FAIL";

            try
            {
                var q = db.ProductGroups.Find(groupid);

                db.ProductGroups.Remove(q);

                db.SaveChanges();

                result = "DONE";
            }
            catch
            {

            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
