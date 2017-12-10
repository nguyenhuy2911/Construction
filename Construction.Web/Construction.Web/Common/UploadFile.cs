﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Web.Hosting;
using Construction.Domain.Helper;

namespace Construction.Web.Common
{
    public static class UploadFile
    {
        public static void UploadProjectImage(HttpFileCollectionBase fileCollection, string fileName, string uniqueFolder)
        {
            foreach (string _fileName in fileCollection)
            {
                HttpPostedFileBase file = fileCollection[_fileName];
                string path = string.Format(@"~\uploads\images\project\{0}", uniqueFolder);
                file.UploadImage(fileName, path);
            }
        }
    }
}