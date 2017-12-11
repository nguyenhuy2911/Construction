using Construction.Web.Service;
using Construction.Web.Service.FrontEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Construction.Web.Controllers
{
    public class FE_ProjectController : Controller
    {
        private FEProject_Service _project_Service { get; set; }
        public FE_ProjectController()
        {
            this._project_Service = new FEProject_Service();
        }
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult HomeItems()
        {
            var model = _project_Service.GetHomeItems();
            return View("~/Views/FE_Project/_HomeItems.cshtml", model);
        }
    }
}