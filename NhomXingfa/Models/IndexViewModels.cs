﻿using System;
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
        public List<Product> lstListProjects { get; set; }
    }
}