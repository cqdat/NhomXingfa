using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NhomXingfa.Areas.Quantri.Models;
using NhomXingfa.Areas.Quantri.Models.DataModels;
using NhomXingfa.Areas.Quantri.Utilities;

namespace NhomXingfa.Models
{
    public class AboutUsViewModel
    {
        public Blog aboutus { get; set; }
        public List<Blog> lstAboutMoreLeftMenu { get; set; }
        public List<Category> lstCategory { get; set; }
        public List<Blog> lstLastNews { get; set; }
    }
}