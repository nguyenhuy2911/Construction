using Construction.Domain.Core;
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
            var data = _productManager.GetAll(page, p => p.Id) ?? new Result<List<Product>>();
            if (data.Results != null && data.Results.Count > 0)
            {
                var listItem = data.Results.Select(p =>
                new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Alias = p.Alias,
                    Status = p.Status,
                    Thumbnail = Url.ProductImgUrl(p.Thumbnail),
                }).ToList();
                data.Results = listItem;
            }
            return data;
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
            model.Link = _data.Link;
            model.Thumbnail = Url.ProductImgUrl(_data.Thumbnail);
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
        public Result<Product> UpdateProduct(ProductCrudViewModel model)
        {
            var result = new Result<Product>();
            try
            {
                var _saveData = new Product();
                _saveData = _productManager.GetById(model.Id);
                _saveData.Name = model.Name;
                _saveData.Alias = model.Name.GenerateFriendlyName();
                _saveData.Status = model.Status;
                _saveData.Description = WebUtility.HtmlEncode(model.Description);
                _saveData.MetaKeyWord = model.MetaKeyWord;
                _saveData.MetaDescription = model.MetaDescription;
                _productManager.Update(_saveData);                
                _productManager.Save();            
                return result = new Result<Product>()
                {
                    StatusCode = 0,
                    Results = _saveData,
                };
            }
            catch (EntityException ex)
            {
                return result;
            }
            catch (Exception ex)
            {

                return result;
            }

        }

        public Result<Product> UploadImage(ProductCrudViewModel model)
        {
            var result = new Result<Product>();
            try
            {
                var _saveData = new Product();
                _saveData = _productManager.GetById(model.Id);
                if (model.FileCollection != null && model.FileCollection.Count > 0)
                {
                    _saveData.Thumbnail = string.Format("{0}/{1}.{2}", _saveData.Id, _saveData.Alias, "png");
                    UploadFile.UploadProductImage(model.FileCollection, _saveData.Alias, _saveData.Id.ToString());
                }
                _productManager.Update(_saveData);
                _productManager.Save();
                return result = new Result<Product>()
                {
                    StatusCode = 0,
                    Results = _saveData,
                };
            }
            catch (EntityException ex)
            {
                return result;
            }
            catch (Exception ex)
            {

                return result;
            }

        }

        public Result<Product> Upload360(ProductCrudViewModel model)
        {
            var result = new Result<Product>();
            try
            {
                var _saveData = new Product();
                _saveData = _productManager.GetById(model.Id);                   
                if (model.File_360 != null && !string.IsNullOrEmpty(model.File_360.FileName))
                {
                    _saveData.Link = string.Format("{0}/{1}.{2}", _saveData.Id.ToString(), _saveData.Alias, "html");
                    UploadFile.UploadProduct360File(model.File_360, _saveData.Alias, _saveData.Id.ToString());
                }
                _productManager.Update(_saveData);
                _productManager.Save();
                return result = new Result<Product>()
                {
                    StatusCode = 0,
                    Results = _saveData,
                };
            }
            catch (EntityException ex)
            {
                return result;
            }
            catch (Exception ex)
            {

                return result;
            }

        }

    }
}