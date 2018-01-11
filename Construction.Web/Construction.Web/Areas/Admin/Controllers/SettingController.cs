using Construction.Web.Areas.Admin.Models.Setting;
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
    [RoutePrefix("cai-dat")]
    public class SettingController : Controller
    {
        private readonly Setting_Service _setting_Service;

        public SettingController()
        {
            this._setting_Service = new Setting_Service();
        }

        [Route]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            ViewBag.Title = "Cài đặt";
            var model = new SettingViewModel();
            return View(model);
        }

        [HttpPost]
        [Route("get-list")]
        public string GetServices(SettingViewModel model)
        {
            var data = _setting_Service.GetSettings(model.Page);
            string jsonData = JsonConvert.SerializeObject(data);
            return jsonData;
        }

        [HttpGet]
        [Route("them-moi")]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Create()
        {
            var model = new SettingCrudViewModel();
            ViewBag.Title = "Thêm cài đặt";
            return View("~/Areas/Admin/Views/Setting/Crud.cshtml", model);
        }

        [HttpGet]
        [Route("sua/{id}")]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Edit(int id)
        {
            var model = new SettingCrudViewModel();
            model = _setting_Service.Find(id);
            ViewBag.Title = "Cập nhật";
            return View("~/Areas/Admin/Views/Setting/Crud.cshtml", model);
        }

        [HttpPost]
        [Route("save")]
        public ActionResult Save(SettingCrudViewModel model)
        {
            int id = 0;
            if (!string.IsNullOrEmpty(model.Id.ToString()) && model.Id > 0)
            {
                id = _setting_Service.UpdateSetting(model);
            }
            else
            {
                id = _setting_Service.CreateSetting(model);

            }
            return RedirectToAction("Edit", new { id = id });
        }
    }
}