using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Construction.Web.Common.Enum
{
    public enum ACTIVE_TYPE
    {
        [Display(Name = "Tất cả")]
        All = -1,

        [Display(Name = "Bị khóa")]
        BLOCK = 0,

        [Display(Name = "Kích hoạt")]
        ACTIVE = 1,
       
    }
}