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
        public bool? isAll { get; set; }
        public List<Product> listduan { get; set; }
        public string SEOTitle { get; set; }
        public string SEOKeywords { get; set; }
        public string SEOMetadescription { get; set; }
    }

    public class DetailProductViewModel
    {
        public Product product { get; set; }
        public Category category { get; set; }
        public List<ImageData> listimage { get; set; }
    }

    public class ImageData
    {
        public string urlimg { get; set; }
        public string urlthumb { get; set; }
        public string title { get; set; }
    }

    public class NewsViewModel
    {
        public List<Blog> blogs { get; set; }
        public List<Category> categories { get; set; }
        public Category category { get; set; }
        public List<Blog> recent { get; set; }
    }

    public class DetailNewsViewModel
    {
        public Blog blog { get; set; }
        public List<Category> categories { get; set; }
        public Category category { get; set; }
        public List<Blog> recents { get; set; }
    }
}