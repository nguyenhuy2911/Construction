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
            return model;
        }
        public int CreateService(ServiceCrudViewModel model)
        {
            try
            {
                var _createData = new Construction.Domain.Models.Service();
                _createData.Name = model.Name;
                _createData.Alias = model.Name.GenerateFriendlyName();
                _createData.Status = model.Status;
                _serviceManager.Add(_createData);
                _serviceManager.Save();
                return _createData.Id;
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
                var _updateData = new Construction.Domain.Models.Service();
                _updateData = _serviceManager.GetById(model.Id);
                _updateData.Name = model.Name;
                _updateData.Alias = model.Name.GenerateFriendlyName();
                _updateData.Status = model.Status;
                _serviceManager.Update(_updateData);
                _serviceManager.Save();
                return _updateData.Id;
            }
            catch (Exception ex)
            {

                return 0;
            }

        }
    }
}