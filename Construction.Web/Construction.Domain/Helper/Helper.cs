using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.IO.Compression;
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
        public static string UploadImage(this HttpPostedFileBase file, string fileName, string path)
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

        public static void UploadExtractZipFile(this HttpPostedFileBase file, string fileName, string path)
        {
            if (!Directory.Exists(HostingEnvironment.MapPath(path)))
                Directory.CreateDirectory(HostingEnvironment.MapPath(path));
            else
            {
                var dir = new DirectoryInfo(HostingEnvironment.MapPath(path));
                foreach (FileInfo fileinfo in dir.GetFiles())
                {
                    fileinfo.Delete();
                }
                foreach (DirectoryInfo dirchild in dir.GetDirectories())
                {
                    dirchild.Delete(true);
                }
            }
            string zipPath = path + @"\" + fileName + ".zip";
            file.SaveAs(HostingEnvironment.MapPath(zipPath));
            string extractPath = HostingEnvironment.MapPath(path);
            ZipFile.ExtractToDirectory(HostingEnvironment.MapPath(zipPath), extractPath);
            File.Delete(HostingEnvironment.MapPath(zipPath));
            FileInfo fileInfo = new FileInfo(string.Format("{0}/{1}", HostingEnvironment.MapPath(path), "Sample.html"));
            fileInfo.CopyTo(string.Format(string.Format("{0}/{1}.{2}", HostingEnvironment.MapPath(path), fileName,"html"),true));
        }

    }
}