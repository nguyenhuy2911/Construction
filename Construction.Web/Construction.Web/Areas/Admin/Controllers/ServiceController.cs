using Construction.Web.Areas.Admin.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Construction.Web.Areas.Admin.Controllers
{
    [RouteArea("admin")]
    [RoutePrefix("dich-vu")]
    public class ServiceController : Controller
    {
        [Route]
        public ActionResult Index()
        {
            var model = new ServiceViewModel();
            return View();
        }

        [HttpGet]
        [Route("them-moi")]
        public ActionResult Create()
        {
            var model = new ServiceCrudViewModel();
            return View("~/Areas/Admin/Views/Service/Crud.cshtml", model);
        }

        [HttpGet]
        [Route("sua/{id}")]
        public ActionResult Edit(int id)
        {
            var model = new ServiceCrudViewModel();
          //  model = _category_Service.Find(id);
            return View("~/Areas/Admin/Views/Service/Crud.cshtml", model);
        }
    }
}