using Construction.Domain.Helper.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction.Web.Areas.Admin.Models.Category
{
    public class CategoryCrudViewModel : Construction.Domain.Models.Category
    {
        public bool Active
        {
            get
            {
                if (this.Status == (int)ACTIVE_TYPE.ACTIVE)
                    return true;
                else
                    return false;
            }
        }
    }
}