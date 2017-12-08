using Construction.Domain.Core;
using Construction.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction.Web.Areas.Admin.Models.Category
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            GridHeader = DataTableGridHelper.GetHeaderJson<Category_Grid_Column>();
        }
        public string GridHeader { get; set; }
        public Page Page { get; set; }
    }
    public class Category_Grid_Column
    {
        [TableHeader(title = "Id")]
        public string Id { get; set; }

        [TableHeader(title = "Tên danh mục")]
        public string Name { get; set; }

        [TableHeader(title = "Alias")]
        public string Alias { get; set; }

        [TableHeader(title ="Trạng thái")]
        public int Status { get; set; }

        [TableHeader(title = "", className = "text-center")]
        public int Action { get; set; }
    }
}