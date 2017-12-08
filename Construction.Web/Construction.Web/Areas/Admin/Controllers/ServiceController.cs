using Construction.Web.Areas.Admin.Models.Service;
using Construction.Web.Service;
using Newtonsoft.Json;
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
        private Service_Service _service_Service { get; set; }
        public ServiceController()
        {
            this._service_Service = new Service_Service();
        }
        [Route]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            var model = new ServiceViewModel();
            ViewBag.Title = "Danh sách dịch vụ";
            return View(model);
        }

        [HttpPost]
        [Route("get-list")]
        public string GetServices(ServiceViewModel model)
        {
            var data = _service_Service.GetServices(model.Page);
            string jsonData = JsonConvert.SerializeObject(data);
            return jsonData;
        }

        [HttpGet]
        [Route("them-moi")]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Create()
        {
            var model = new ServiceCrudViewModel();
            ViewBag.Title = "Thêm mới dịch vụ";
            return View("~/Areas/Admin/Views/Service/Crud.cshtml", model);
        }

        [HttpGet]
        [Route("sua/{id}")]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Edit(int id)
        {
            var model = new ServiceCrudViewModel();
            model = _service_Service.Find(id);
            ViewBag.Title = "Cập nhật dịch vụ";
            return View("~/Areas/Admin/Views/Service/Crud.cshtml", model);
        }

        [HttpPost]
        [Route("save")]
        public ActionResult Save(ServiceCrudViewModel model)
        {
            int id = 0;
            if (!string.IsNullOrEmpty(model.Id.ToString()) && model.Id > 0)
            {
                id = _service_Service.UpdateService(model);
            }
            else
            {
                id = _service_Service.CreateService(model);

            }
            return RedirectToAction("Edit", new { id = id });
        }
    }
}