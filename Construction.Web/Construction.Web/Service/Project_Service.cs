using Construction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Construction.Domain.Core;
using Construction.Web.Areas.Admin.Models.Category;
using Construction.Domain.Helper;
using Construction.Web.Areas.Admin.Models.Project;

namespace Construction.Web.Service
{
    public class Project_Service : BaseService
    {
        private readonly DataBaseManager<Project> _projectManager = DataBaseManager<Project>.Create();
        public Result<List<Project>> GetPojects(Page page)
        {
            return _projectManager.GetAll(page, p=> p.Id);
        }
        public ProjectCrudViewModel Find(int id)
        {
            var _data = _projectManager.GetById(id);
            var model = new ProjectCrudViewModel();
            model.Id = _data.Id;
            model.Name = _data.Name;
            model.Alias = _data.Alias;
            model.Status = _data.Status;
            return model;
        }
        public int CreateProject(ProjectCrudViewModel model)
        {
            try
            {
                var _createData = new Project();
                _createData.Name = model.Name;
                _createData.Alias = model.Name.GenerateFriendlyName();
                _createData.Status = model.Status;
                _projectManager.Add(_createData);
                _projectManager.Save();
                return _createData.Id;
            }
            catch (Exception ex)
            {

                return 0;
            }
            
        }
        public int UpdatePoject(ProjectCrudViewModel model)
        {
            try
            {
                var _updateData = new Project();
                _updateData = _projectManager.GetById(model.Id);
                _updateData.Name = model.Name;
                _updateData.Alias = model.Name.GenerateFriendlyName();
                _updateData.Status = model.Status;
                _projectManager.Update(_updateData);
                _projectManager.Save();
                return _updateData.Id;
            }
            catch (Exception ex)
            {

                return 0;
            }

        }

    }
}