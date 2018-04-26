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

        public FE_ServiceController()
        {
        }
        public ActionResult HomeItems()
        {
            return View();
        }
    }
}