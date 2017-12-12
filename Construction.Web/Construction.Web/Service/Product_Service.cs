﻿using Construction.Domain.Core;
using Construction.Domain.Helper;
using Construction.Domain.Models;
using Construction.Web.Areas.Admin.Models.Product;
using Construction.Web.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;

namespace Construction.Web.Service
{
    public class Product_Service : BaseService
    {
        private readonly DataBaseManager<Product> _productManager = DataBaseManager<Product>.Create();
        public Result<List<Product>> GetProducts(Page page)
        {
            return _productManager.GetAll(page, p => p.Id);
        }
        public ProductCrudViewModel Find(int id)
        {
            var _data = _productManager.GetById(id);
            var model = new ProductCrudViewModel();
            model.Id = _data.Id;
            model.Name = _data.Name;
            model.Alias = _data.Alias;
            model.Status = _data.Status;
            model.ShortDescription = _data.ShortDescription;
            model.Description = _data.Description;
            return model;
        }
        public int CreateProduct(ProductCrudViewModel model)
        {
            try
            {
                var _saveData = new Product();
                _saveData.Name = model.Name;
                _saveData.Alias = model.Name.GenerateFriendlyName();
                _saveData.Status = model.Status;
                _saveData.CategoryId = 2;
                _saveData.ServiceId = 2;
                _saveData.Description = WebUtility.HtmlEncode(model.Description);
                _saveData.MetaKeyWord = model.MetaKeyWord;
                _saveData.MetaDescription = model.MetaDescription;
                _productManager.Add(_saveData);
                _productManager.Save();
                return _saveData.Id;
            }
            catch (EntityException ex)
            {
                return 0;
            }
            catch (Exception ex)
            {

                return 0;
            }

        }
        public int UpdateProduct(ProductCrudViewModel model)
        {
            try
            {
                var _saveData = new Product();
                _saveData = _productManager.GetById(model.Id);
                _saveData.Name = model.Name;
                _saveData.Alias = model.Name.GenerateFriendlyName();
                _saveData.Status = model.Status;
                _saveData.Description = WebUtility.HtmlEncode(model.Description);
                _saveData.Thumbnail = string.Format("{0}/{1}.{2}", _saveData.Id, _saveData.Alias, "png");
                _saveData.MetaKeyWord = model.MetaKeyWord;
                _saveData.MetaDescription = model.MetaDescription;
                _productManager.Update(_saveData);
                _productManager.Save();
                if (model.FileCollection != null && model.FileCollection.Count > 0)
                    UploadFile.UploadProductImage(model.FileCollection, _saveData.Alias, _saveData.Id.ToString());
                return _saveData.Id;
            }
            catch (EntityException ex)
            {
                return 0;
            }
            catch (Exception ex)
            {

                return 0;
            }

        }

    }
}