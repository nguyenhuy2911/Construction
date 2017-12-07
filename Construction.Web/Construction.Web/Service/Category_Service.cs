using Construction.Domain.Models;
using Construction.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Construction.Web.Common.Extensions;
namespace Construction.Web.Service
{
    public class Category_Service : BaseService
    {
        public Result<List<Category>> GetCategories(Page page)
        {

            var list = new List<Category>();
            list = db.Categories.OrderBy(p => p.Id).GetPage(page).ToList();
            int totalRow = db.Categories.Count();
            var response = new Result<List<Category>>()
            {
                Results = list,
                StatusCode = 0,
                TotalRow = totalRow
            };
            return response;
        }

    }
}