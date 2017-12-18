using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Construction.Web.Common
{
    public static class UrlHelperExtentions
    {
        public static string ProjectImgUrl(this UrlHelper url, string sortPath)
        {
            return !string.IsNullOrEmpty(sortPath) ? url.Content("~/uploads/images/project/" + sortPath) : "";
        }

        public static string Project360Url(this UrlHelper url, string sortPath)
        {
            return !string.IsNullOrEmpty(sortPath) ? url.Content("~/uploads/360/project/" + sortPath) : "";
        }

        public static string ProductImgUrl(this UrlHelper url, string sortPath)
        {
            return !string.IsNullOrEmpty(sortPath) ? url.Content("~/uploads/images/product/" + sortPath) : "";
        }

        public static string Product360Url(this UrlHelper url, string sortPath)
        {
            return !string.IsNullOrEmpty(sortPath) ? url.Content("~/uploads/360/product/" + sortPath) : "";
        }


    }
}