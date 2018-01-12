using Construction.Domain.Infrastructure;
using Construction.Web.Service.Frontend;
using Construction.Web.Service.FrontEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Construction.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly FESetting_Service _setting_Service;
        public HomeController()
        {
            this._setting_Service = new FESetting_Service();
        }

        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {          
            return View();
        }
               
        public ActionResult About()
        {
            var model = _setting_Service.GetAboutPage();
            return View(model);
        }

        public ActionResult Contact()
        {
            var model = _setting_Service.GetContactPage();
            return View(model);
        }

        public ActionResult Service()
        {
            var model = _setting_Service.GetServiceContent();
            return View(model);
        }
    }
}