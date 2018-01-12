using Construction.Domain.Core;
using Construction.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction.Web.Areas.Admin.Models.Setting
{
    public class SettingViewModel
    {
        public SettingViewModel()
        {
            GridHeader = DataTableGridHelper.GetHeaderJson<Setting_Grid_Column>();
        }
        public string GridHeader { get; set; }
        public Page Page { get; set; }
    }

    public class Setting_Grid_Column
    {
        [TableHeader(title = "Loại cài đặt")]
        public string Name { get; set; }

        [TableHeader(title = "Giá trị")]
        public string Description { get; set; }

        [TableHeader(title = "", className = "text-center")]
        public int Action { get; set; }
    }
}