using Construction.Domain.Core;
using Construction.Domain.Helper.Enum;
using Construction.Domain.Models;
using Construction.Web.Models;
using System.Collections.Generic;

namespace Construction.Web.Service.FrontEnd
{
    public class FEProduct_Service : BaseService
    {
        private readonly DataBaseManager<Product> _productManager = DataBaseManager<Product>.Create();
        public Product_HomeItemsViewModel GetHomeItems()
        {
            int activeStatus = (int)ACTIVE_TYPE.ACTIVE;
            var items = _productManager.GetPage(new Page(0, 9), p=>p.Status == activeStatus, p => p.Id)?.Results ?? new List<Product>();
            return new Product_HomeItemsViewModel()
            {
                Items = items
            };
        }

    }
}