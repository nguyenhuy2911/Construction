using Construction.Web.Service.Frontend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Construction.Web.Controllers
{
    public class FE_ServiceController : Controller
    {
        private readonly FESetting_Service _setting_Service;

        public FE_ServiceController()
        {
            this._setting_Service = new FESetting_Service();
        }
        public ActionResult HomeItems()
        {
          //  var model = _setting_Service.GetServiceContent();
           // return View(model);
            return View();
        }
    }
}