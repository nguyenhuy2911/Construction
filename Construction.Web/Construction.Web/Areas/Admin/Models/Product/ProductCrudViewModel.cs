using Construction.Domain.Helper.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction.Web.Areas.Admin.Models.Product
{
    public class ProductCrudViewModel : Construction.Domain.Models.Product
    {
        public bool Active => this.Status == (int)ACTIVE_TYPE.ACTIVE ? true : false;
        public HttpFileCollectionBase FileCollection { get; set; }
        public HttpPostedFileBase File_360 { get; set; }
    }
}