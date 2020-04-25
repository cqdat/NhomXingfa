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
        public List<Product> lstProjects { get; set; }
        public List<Category> lstCatetory { get; set; }
        public List<Blog> lstNews { get; set; }
    }
}