using Construction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Construction.Domain.Core;

namespace Construction.Web.Service
{
    public class Category_Service : BaseService
    {
        private readonly DataBaseManager<Category> _categoryManager = DataBaseManager<Category>.Create();
        public Result<List<Category>> GetCategories(Page page)
        {
            return _categoryManager.GetAll(page, p=> p.Id);
        }

    }
}