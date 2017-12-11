using Construction.Domain.Core;
using Construction.Domain.Helper.Enum;
using Construction.Domain.Models;
using Construction.Web.Common;
using Construction.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Construction.Web.Service.FrontEnd
{
    public class FEProduct_Service : BaseService
    {
        private readonly DataBaseManager<Product> _productManager = DataBaseManager<Product>.Create();
        public Product_HomeItemsViewModel GetHomeItems()
        {
            int activeStatus = (int)ACTIVE_TYPE.ACTIVE;
            var items = _productManager.GetPage(new Page(0, 9), p => p.Status == activeStatus, p => p.Id)?.Results ?? new List<Product>();
            return new Product_HomeItemsViewModel()
            {
                Items = items
            };
        }

        public Product_ItemsViewModel GetItems(Page page)
        {
            int activeStatus = (int)ACTIVE_TYPE.ACTIVE;
            var items = new Result<List<Item>>();
            UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var datas = _productManager.GetPage(new Page(0, 9), p => p.Status == activeStatus, p => p.Id);

            if (datas != null && datas.Results != null && datas.Results.Count > 0)
            {
                items.TotalRow = datas.TotalRow;
                items.Results = datas.Results.Select(p => new Item()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Thumbnail = url.ProductImgUrl(p.Thumbnail),
                    ShortDescription = p.ShortDescription,
                    Action = "san-pam"
                }).ToList();
            }
            return new Product_ItemsViewModel()
            {
                Items = items
            };
        }

    }
}