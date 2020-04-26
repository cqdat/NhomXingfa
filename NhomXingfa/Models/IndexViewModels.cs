using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NhomXingfa.Areas.Quantri.Models.DataModels;

namespace NhomXingfa.Models
{
    public class IndexViewModels
    {
        public List<Slide> lstHomeBanner { get; set; }
        public Blog blogGioiThieu { get; set; }
        public List<ProductGroup> lstProductNoibat { get; set; }

        public List<ProductGroup> listSPMoi { get; set; }

        public List<Product> lstListProjects { get; set; }
        public List<Blog> lstLastNews { get; set; }
        public List<Blog> lstServices { get; set; }
    }
    public class MenuViewModel
    {
        public Information Phone { get; set; }
        public Information Email { get; set; }
        public List<Category> lstProductCategory { get; set; }
        public List<Category> lstNewsCategory { get; set; }
    }

    public class FooterViewModel
    {
        public List<Information> lstInformation { get; set; }
        public List<Category> lstNewsCategory { get; set; }
    }
}