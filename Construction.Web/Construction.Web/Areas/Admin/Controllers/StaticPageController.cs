using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Construction.Web.Areas.Admin.Controllers
{
    public class StaticPageController : Controller
    {
        // GET: Admin/StaticPage
        public ActionResult Index()
        {
            return View();
        }
    }
}