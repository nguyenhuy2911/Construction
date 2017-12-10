using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;

namespace Construction.Domain.Helper
{
    public static class Helper
    {
       
        public static string GetDisplayName(this object value)
        {
            return value.GetType().GetMember(value.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .Name;
        }
        public static string UploadImage(this HttpPostedFileBase file, string fileName , string path)
        {
            if (file != null && file.ContentLength > 0)
            {
               // string ext = Path.GetExtension(file.FileName);
                if (!Directory.Exists(HostingEnvironment.MapPath(path)))
                {
                    Directory.CreateDirectory(HostingEnvironment.MapPath(path));
                }
                path += @"\" + fileName + ".png";
                file.SaveAs(HostingEnvironment.MapPath(path));
            }

            return path;
        }

    }
}