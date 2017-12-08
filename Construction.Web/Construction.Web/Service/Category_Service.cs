using Construction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Construction.Domain.Core;
using Construction.Web.Areas.Admin.Models.Category;
using Construction.Domain.Helper;
namespace Construction.Web.Service
{
    public class Category_Service : BaseService
    {
        private readonly DataBaseManager<Category> _categoryManager = DataBaseManager<Category>.Create();
        public Result<List<Category>> GetCategories(Page page)
        {
            return _categoryManager.GetAll(page, p=> p.Id);
        }
        public CategoryCrudViewModel Find(int id)
        {
            var _data = _categoryManager.GetById(id);
            var model = new CategoryCrudViewModel();
            model.Id = _data.Id;
            model.Name = _data.Name;
            model.Alias = _data.Alias;
            model.Status = _data.Status;
            return model;
        }
        public int CreateCategory(CategoryCrudViewModel model)
        {
            try
            {
                var _createData = new Category();
                _createData.Name = model.Name;
                _createData.Alias = model.Name.GenerateFriendlyName();
                _createData.Status = model.Status;
                _categoryManager.Add(_createData);
                _categoryManager.Save();
                return _createData.Id;
            }
            catch (Exception ex)
            {

                return 0;
            }
            
        }
        public int UpdateCategory(CategoryCrudViewModel model)
        {
            try
            {
                var _updateData = new Category();
                _updateData = _categoryManager.GetById(model.Id);
                _updateData.Name = model.Name;
                _updateData.Alias = model.Name.GenerateFriendlyName();
                _updateData.Status = model.Status;
                _categoryManager.Update(_updateData);
                _categoryManager.Save();
                return _updateData.Id;
            }
            catch (Exception ex)
            {

                return 0;
            }

        }

    }
}