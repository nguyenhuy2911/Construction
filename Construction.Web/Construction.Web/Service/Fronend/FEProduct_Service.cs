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

        public Product_Detail_ViewModel GetDetailItem(int id)
        {
            var item = _productManager.GetById(id);
            return new Product_Detail_ViewModel()
            {
                Item = item
            };
        }

        public Product_ItemsViewModel GetItems(Page page)
        {
            int activeStatus = (int)ACTIVE_TYPE.ACTIVE;
            var pagination = new Pagination<Item>(page.PageNumber, page.PageSize);           
            var datas = _productManager.GetPage(page, p => p.Status == activeStatus, p => p.Id);

            if (datas != null && datas.Results != null && datas.Results.Count > 0)
            {
                pagination.TotalRow = datas.TotalRow;
                pagination.Link = "san-pham";
                pagination.Items = datas.Results.Select(p => new Item()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Thumbnail = Url.ProductImgUrl(p.Thumbnail),
                    ShortDescription = p.ShortDescription,
                    Link = Url.RouteUrl("ProductDetail", new {alias= p.Alias, id = p.Id }) 
                }).ToList();
            }
            return new Product_ItemsViewModel()
            {
                Data = pagination
            };
        }

    }
}