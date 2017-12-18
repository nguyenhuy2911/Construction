using Construction.Domain.Core;
using Construction.Web.Service;
using Construction.Web.Service.FrontEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Construction.Web.Controllers
{
    [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
    public class FE_ProjectController : Controller
    {
        private FEProject_Service _project_Service { get; set; }
        public FE_ProjectController()
        {
            this._project_Service = new FEProject_Service();
        }
        public ActionResult Index(int pageNumber = 0)
        {
            var page = new Page(pageNumber, 9);
            var model = _project_Service.GetItems(page);
            return View(model);
        }
        
        public ActionResult HomeItems()
        {
            var model = _project_Service.GetHomeItems();
            return View("~/Views/FE_Project/_HomeItems.cshtml", model);
        }

        public ActionResult RelateItems()
        {
            var model = _project_Service.GetRelateItems();
            return View("~/Views/_Partial/RelateItems.cshtml", model);
        }

        public ActionResult Detail(string alias, int id)
        {
            var model = _project_Service.GetDetailItem(id);
            return View(model);
        }
    }
}