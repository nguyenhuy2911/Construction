﻿using Construction.Domain.Core;
using Construction.Web.Service.FrontEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Construction.Web.Controllers
{
    [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
    public class FE_ProductController : Controller
    {
        private FEProduct_Service _product_Service { get; set; }
        public FE_ProductController()
        {
            this._product_Service = new FEProduct_Service();
        }

        public ActionResult Index(int pageNumber = 0)
        {
            var page = new Page(pageNumber, 9);
            var model = _product_Service.GetItems(page);
            return View(model);
        }

        public ActionResult HomeItems()
        {
            var model = _product_Service.GetHomeItems();
            return View(model);
        }

        public ActionResult RelateItems()
        {
            var model = _product_Service.GetRelateItems();
            return View("~/Views/_Partial/RelateItems.cshtml", model);
        }

        public ActionResult Detail(string alias, int id)
        {
            var model = _product_Service.GetDetailItem(id);
            return View(model);
        }
    }
}