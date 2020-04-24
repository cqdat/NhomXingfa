using NhomXingfa.Areas.Quantri.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhomXingfa.Models
{
    public class ProductViewModel
    {
        public List<Product> product { get; set; }
        public List<Category> categories { get; set; }
        public Category category { get; set; }
    }

    public class DetailProductViewModel
    {
        public Product product { get; set; }
    }
}