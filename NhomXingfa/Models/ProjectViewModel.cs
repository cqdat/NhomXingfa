using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NhomXingfa.Models;
using NhomXingfa.Areas.Quantri.Models.DataModels;

namespace NhomXingfa.Models
{
    public class ProjectViewModel
    {
        public Product detail { get; set; }
        public List<ProductImage> lstImages { get; set; }
        public List<Product> lstProjects { get; set; }
        public List<Product> lstProjects1 { get; set; }
        public List<Category> lstCategory { get; set; }
        public List<Blog> lstNews { get; set; }
    }
}