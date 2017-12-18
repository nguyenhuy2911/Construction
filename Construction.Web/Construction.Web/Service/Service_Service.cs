using Construction.Domain.Core;
using Construction.Web.Areas.Admin.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Construction.Domain.Helper;
namespace Construction.Web.Service
{
    public class Service_Service
    {
        private readonly DataBaseManager<Construction.Domain.Models.Service> _serviceManager = DataBaseManager<Construction.Domain.Models.Service>.Create();
        public Result<List<Construction.Domain.Models.Service>> GetServices(Page page)
        {
            return _serviceManager.GetAll(page, p => p.Id);
        }
        public ServiceCrudViewModel Find(int id)
        {
            var _data = _serviceManager.GetById(id);
            var model = new ServiceCrudViewModel();
            model.Id = _data.Id;
            model.Name = _data.Name;
            model.Alias = _data.Alias;
            model.Status = _data.Status;
            model.MetaKeyWord = _data.MetaKeyWord;
            model.MetaDescription = _data.MetaDescription;
            return model;
        }
        public int CreateService(ServiceCrudViewModel model)
        {
            try
            {
                var _saveData = new Construction.Domain.Models.Service();
                _saveData.Name = model.Name;
                _saveData.Alias = model.Name.GenerateFriendlyName();
                _saveData.Status = model.Status;
                _saveData.MetaKeyWord = model.MetaKeyWord;
                _saveData.MetaDescription = model.MetaDescription;
                _serviceManager.Add(_saveData);
                _serviceManager.Save();
                return _saveData.Id;
            }
            catch (Exception ex)
            {

                return 0;
            }

        }
        public int UpdateService(ServiceCrudViewModel model)
        {
            try
            {
                var _saveData = new Construction.Domain.Models.Service();
                _saveData = _serviceManager.GetById(model.Id);
                _saveData.Name = model.Name;
                _saveData.Alias = model.Name.GenerateFriendlyName();
                _saveData.Status = model.Status;
                _saveData.MetaKeyWord = model.MetaKeyWord;
                _saveData.MetaDescription = model.MetaDescription;
                _serviceManager.Update(_saveData);
                _serviceManager.Save();
                return _saveData.Id;
            }
            catch (Exception ex)
            {

                return 0;
            }

        }
    }
}