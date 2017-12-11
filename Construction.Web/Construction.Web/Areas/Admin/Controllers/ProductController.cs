
using Construction.Web.Areas.Admin.Models.Product;
using Construction.Web.Service;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace Construction.Web.Areas.Admin.Controllers
{
    [RouteArea("admin")]
    [RoutePrefix("san-pham")]
    public class ProductController : Controller
    {

        private Product_Service _project_Service { get; set; }
        public ProductController()
        {
            this._project_Service = new Product_Service();
        }
        [Route]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            var model = new ProductViewModel();
            ViewBag.Title = "Danh sách Sản phẩm";
            return View(model);
        }

        [HttpPost]
        [Route("get-list")]
        public string GetServices(ProductViewModel model)
        {
            var data = _project_Service.GetProducts(model.Page);
            string jsonData = JsonConvert.SerializeObject(data);
            return jsonData;
        }

        [HttpGet]
        [Route("them-moi")]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Create()
        {
            var model = new ProductCrudViewModel();
            ViewBag.Title = "Thêm mới sản phẩm";
            return View("~/Areas/Admin/Views/Product/Crud.cshtml", model);
        }

        [HttpGet]
        [Route("sua/{id}")]
        [OutputCache(CacheProfile = "SystemCache", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Edit(int id)
        {
            var model = new ProductCrudViewModel();
            model = _project_Service.Find(id);
            ViewBag.Title = "Cập nhật sản phẩm";
            return View("~/Areas/Admin/Views/Product/Crud.cshtml", model);
        }

        [HttpPost]
        [Route("save")]
        public ActionResult Save(ProductCrudViewModel model)
        {
            int id = 0;

            if (!string.IsNullOrEmpty(model.Id.ToString()) && model.Id > 0)
            {
                id = _project_Service.UpdateProduct(model);
            }
            else
            {
                id = _project_Service.CreateProduct(model);

            }
            return RedirectToAction("Edit", new { id = id });
        }

        [HttpPost]
        [Route("save-image")]
        public int SaveImage(int id)
        {
            var model = _project_Service.Find(id);
            model.FileCollection = Request.Files;
            _project_Service.UpdateProduct(model);
            return 0;
        }
    }
}