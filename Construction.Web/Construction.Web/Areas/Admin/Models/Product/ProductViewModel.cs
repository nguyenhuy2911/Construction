﻿using Construction.Domain.Core;
using Construction.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction.Web.Areas.Admin.Models.Product
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            GridHeader = DataTableGridHelper.GetHeaderJson<Product_Grid_Column>();
        }
        public string GridHeader { get; set; }
        public Page Page { get; set; }
    }
    public class Product_Grid_Column
    {
        [TableHeader(title = "Id")]
        public string Id { get; set; }

        [TableHeader(title = "Hình")]
        public string Thumbnail { get; set; }

        [TableHeader(title = "Tên sản phẩm")]
        public string Name { get; set; }

        [TableHeader(title = "Alias")]
        public string Alias { get; set; }

        [TableHeader(title ="Trạng thái")]
        public int Status { get; set; }

        [TableHeader(title = "", className = "text-center")]
        public int Action { get; set; }
    }
}