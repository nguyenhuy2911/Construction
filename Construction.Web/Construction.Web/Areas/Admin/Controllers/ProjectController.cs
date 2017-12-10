﻿using Construction.Web.Areas.Admin.Models.Project;
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
    [RoutePrefix("du-an")]
    public class ProjectController : Controller
    {
        private Project_Service _project_Service { get; set; }
        public ProjectController()
        {
            this._project_Service = new Project_Service();
        }
        [Route]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            var model = new ProjectViewModel();
            ViewBag.Title = "Danh sách dự án";
            return View(model);
        }

        [HttpPost]
        [Route("get-list")]
        public string GetServices(ProjectViewModel model)
        {
            var data = _project_Service.GetPojects(model.Page);
            string jsonData = JsonConvert.SerializeObject(data);
            return jsonData;
        }

        [HttpGet]
        [Route("them-moi")]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Create()
        {
            var model = new ProjectCrudViewModel();
            ViewBag.Title = "Thêm mới dự án";
            return View("~/Areas/Admin/Views/Project/Crud.cshtml", model);
        }

        [HttpGet]
        [Route("sua/{id}")]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Edit(int id)
        {
            var model = new ProjectCrudViewModel();
            model = _project_Service.Find(id);
            ViewBag.Title = "Cập nhật dự án";
            return View("~/Areas/Admin/Views/Project/Crud.cshtml", model);
        }

        [HttpPost]
        [Route("save")]
        public ActionResult Save(ProjectCrudViewModel model)
        {
            int id = 0;
           
            if (!string.IsNullOrEmpty(model.Id.ToString()) && model.Id > 0)
            {
                id = _project_Service.UpdatePoject(model);
            }
            else
            {              
                id = _project_Service.CreateProject(model);

            }
            return RedirectToAction("Edit", new { id = id });
        }

        [HttpPost]
        [Route("save-image")]
        public int SaveImage(int id)
        {
            var model = _project_Service.Find(id);
            model.FileCollection = Request.Files;
            _project_Service.UpdatePoject(model);
            return 0;
        }
    }
}