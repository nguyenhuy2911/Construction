using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Construction.Web.Controllers
{
    public class FE_ServiceController : Controller
    {
      
        public ActionResult HomeItems()
        {
            return View();
        }
    }
}