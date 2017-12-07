using Construction.Web.Areas.Admin.Models.Category;
using Construction.Web.Core;
using Construction.Web.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Construction.Web.Areas.Admin.Controllers
{
    
    public class CategoryController : Controller
    {
        private Category_Service _category_Service { get; set; }
        public CategoryController()
        {
            this._category_Service = new Category_Service();
        }

        public ActionResult Index()
        {
            var model = new CategoryViewModel();
            return View(model);
        }

        [HttpGet]
        public string Categories()
        {
            var data = _category_Service.GetCategories(new Page());
            string jsonData = JsonConvert.SerializeObject(data);
            return jsonData;
        }
    }
}