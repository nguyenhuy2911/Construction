using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Construction.Web.Common.Enums
{
    // Maxlenght = 10
    public enum SETTINGTYPE
    {
        [Display(Name = "Logo")]
        LOGO,

        [Display(Name = "Số điện thoại")]
        PHONE,

        [Display(Name = "Facebook link")]
        FACEBOOK,

        [Display(Name = "Địa chỉ")]
        ADDRERSS,

        [Display(Name = "Email")]
        EMAIL,

        [Display(Name = "Liên hệ")]
        CONTACT,

        [Display(Name = "Giới thiệu")]
        ABOUT,

        [Display(Name = "Dịch vụ")]
        SERVICE
    }
}