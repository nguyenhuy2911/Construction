using Construction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Construction.Domain.Core;
using Construction.Web.Areas.Admin.Models.Category;
using Construction.Domain.Helper;
using Construction.Domain.Helper.Enum;

namespace Construction.Web.Service
{
    public class Category_Service : BaseService
    {
        private readonly DataBaseManager<Category> _categoryManager = DataBaseManager<Category>.Create();
        public Result<List<Category>> GetCategories(Page page)
        {
            return _categoryManager.GetAll(page, p=> p.Id);
        }

        public Result<List<Category>> GetAllActivedCategories(Page page)
        {
            int active = (int)ACTIVE_TYPE.ACTIVE;
            return _categoryManager.GetPage(page, p => p.Status == active,  p => p.Id);
        }

        public CategoryCrudViewModel Find(int id)
        {
            var _data = _categoryManager.GetById(id);
            var model = new CategoryCrudViewModel();
            model.Id = _data.Id;
            model.Name = _data.Name;
            model.Alias = _data.Alias;
            model.Status = _data.Status;
            model.MetaKeyWord = _data.MetaKeyWord;
            model.MetaDescription = _data.MetaDescription;
            return model;
        }
        public int CreateCategory(CategoryCrudViewModel model)
        {
            try
            {
                var _saveData = new Category();
                _saveData.Name = model.Name;
                _saveData.Alias = model.Name.GenerateFriendlyName();
                _saveData.Status = model.Status;
                _saveData.MetaKeyWord = model.MetaKeyWord;
                _saveData.MetaDescription = model.MetaDescription;
                _categoryManager.Add(_saveData);
                _categoryManager.Save();
                return _saveData.Id;
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
                var _saveData = new Category();
                _saveData = _categoryManager.GetById(model.Id);
                _saveData.Name = model.Name;
                _saveData.Alias = model.Name.GenerateFriendlyName();
                _saveData.Status = model.Status;
                _saveData.MetaKeyWord = model.MetaKeyWord;
                _saveData.MetaDescription = model.MetaDescription;
                _categoryManager.Update(_saveData);
                _categoryManager.Save();
                return _saveData.Id;
            }
            catch (Exception ex)
            {

                return 0;
            }

        }

    }
}