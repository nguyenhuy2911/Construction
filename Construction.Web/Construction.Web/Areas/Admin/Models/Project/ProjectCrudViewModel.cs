using Construction.Domain.Helper.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Construction.Web.Areas.Admin.Models.Project
{
    public class ProjectCrudViewModel : Construction.Domain.Models.Project
    {
        public bool Active => this.Status == (int)ACTIVE_TYPE.ACTIVE ? true : false;

        public HttpFileCollectionBase FileCollection { get; set; }

        public HttpPostedFileBase File_360 { get; set; }
        public IEnumerable<SelectListItem> ListCategory { get; set; }
        public IEnumerable<SelectListItem> ListService { get; set; }
    }
}