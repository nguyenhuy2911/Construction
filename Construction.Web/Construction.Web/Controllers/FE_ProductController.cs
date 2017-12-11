using Construction.Domain.Core;
using Construction.Web.Service.FrontEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Construction.Web.Controllers
{
    public class FE_ProductController : Controller
    {
        private FEProduct_Service _product_Service { get; set; }
        public FE_ProductController()
        {
            this._product_Service = new FEProduct_Service();
        }
        public ActionResult Index(int pageNumber = 0)
        {
            var page = new Page(pageNumber, 10);
            var model = _product_Service.GetItems(page);
            return View(model);
        }

        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult HomeItems()
        {
            var model = _product_Service.GetHomeItems();
            return View("~/Views/FE_Product/_HomeItems.cshtml", model);
        }
    }
}