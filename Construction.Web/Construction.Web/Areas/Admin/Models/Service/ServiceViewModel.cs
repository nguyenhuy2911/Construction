using Construction.Domain.Core;
using Construction.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction.Web.Areas.Admin.Models.Service
{
    public class ServiceViewModel
    {
        public ServiceViewModel()
        {
            GridHeader = DataTableGridHelper.GetHeaderJson<Servic_Grid_Column>();
        }
        public string GridHeader { get; set; }
        public Page Page { get; set; }
    }
    public class Servic_Grid_Column
    {
        [TableHeader(title = "Id")]
        public string Id { get; set; }

        [TableHeader(title = "Tên dịch vụ")]
        public string Name { get; set; }

        [TableHeader(title = "Alias")]
        public string Alias { get; set; }

        [TableHeader(title = "Trạng thái")]
        public int Status { get; set; }

        [TableHeader(title = "", className = "text-center")]
        public int Action { get; set; }
    }
}