using Construction.Domain.Core;
using Construction.Web.Areas.Admin.Models.Category;
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
    [RoutePrefix("danh-muc")]
    public class CategoryController : Controller
    {
        private Category_Service _category_Service { get; set; }
        public CategoryController()
        {
            this._category_Service = new Category_Service();
        }

        [Route]
        public ActionResult Index()
        {
            var model = new CategoryViewModel();
            return View(model);
        }

        [HttpPost]
        [Route("get-list")]
        public string Categories(CategoryViewModel model)
        {
            var data = _category_Service.GetCategories(model.Page);
            string jsonData = JsonConvert.SerializeObject(data);
            return jsonData;
        }

        [HttpGet]
        [Route("them-moi")]
        public ActionResult Create()
        {
            var model = new CategoryCrudViewModel();
            return View("~/Areas/Admin/Views/Category/Crud.cshtml", model);
        }

        [HttpGet]
        [Route("sua/{id}")]
        public ActionResult Edit(int id)
        {
            var model = new CategoryCrudViewModel();
            model = _category_Service.Find(id);
            return View("~/Areas/Admin/Views/Category/Crud.cshtml", model);
        }

        [HttpPost]
        [Route("save")]
        public ActionResult Save(CategoryCrudViewModel model)
        {
            int id = 0;
            if (!string.IsNullOrEmpty(model.Id.ToString()) && model.Id > 0)
            {
                id = _category_Service.UpdateCategory(model);
            }
            else
            {
                id = _category_Service.CreateCategory(model);
                
            }
            return RedirectToAction("Edit", new { id = id });
        }
    }
}