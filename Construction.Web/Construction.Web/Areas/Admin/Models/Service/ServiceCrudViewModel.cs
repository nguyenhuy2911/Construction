using Construction.Domain.Core;
using Construction.Domain.Helper;
using Construction.Domain.Helper.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction.Web.Areas.Admin.Models.Service
{
    public class ServiceCrudViewModel: Construction.Domain.Models.Service
    {
        public bool Active => this.Status == (int)ACTIVE_TYPE.ACTIVE ? true : false;
        
    }

   
}