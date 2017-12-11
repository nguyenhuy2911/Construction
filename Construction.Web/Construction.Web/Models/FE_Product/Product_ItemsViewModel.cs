using Construction.Domain.Core;
using Construction.Domain.Models;
using System.Collections.Generic;

namespace Construction.Web.Models
{
    public class Product_ItemsViewModel
    {
        public Result<List<Item>> Items { get; set; }
        
    }
}