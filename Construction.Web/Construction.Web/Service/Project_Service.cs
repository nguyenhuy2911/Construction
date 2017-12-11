using Construction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Construction.Domain.Core;
using Construction.Web.Areas.Admin.Models.Category;
using Construction.Domain.Helper;
using Construction.Web.Areas.Admin.Models.Project;
using Construction.Web.Common;
using System.Data.Entity.Core;
using System.Net;

namespace Construction.Web.Service
{
    public class Project_Service : BaseService
    {
        private readonly DataBaseManager<Project> _projectManager = DataBaseManager<Project>.Create();
        public Result<List<Project>> GetPojects(Page page)
        {
            try
            {
                return _projectManager.GetAll(page, p => p.Id);
            }
            catch (EntityException ex)
            {
                return new Result<List<Project>>();
            }
            catch (Exception ex)
            {
                return new Result<List<Project>>();
            }

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
                var _saveData = new Project();
                _saveData.Name = model.Name;
                _saveData.Alias = model.Name.GenerateFriendlyName();
                _saveData.Status = model.Status;
                _saveData.CategoryId = 2;
                _saveData.ServiceId = 2;
                _saveData.Description = WebUtility.HtmlEncode(model.Description);
                _saveData.MetaKeyWord = model.MetaKeyWord;
                _saveData.MetaDescription = model.MetaDescription;
                _projectManager.Add(_saveData);
                _projectManager.Save();
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
        public int UpdateProject(ProjectCrudViewModel model)
        {
            try
            {
                var _saveData = new Project();
                _saveData = _projectManager.GetById(model.Id);
                _saveData.Name = model.Name;
                _saveData.Alias = model.Name.GenerateFriendlyName();
                _saveData.Status = model.Status;
                _saveData.Description = WebUtility.HtmlEncode(model.Description);
                _saveData.Thumbnail = string.Format("{0}/{1}.{2}", _saveData.Id, _saveData.Alias, "png");
                _saveData.MetaKeyWord = model.MetaKeyWord;
                _saveData.MetaDescription = model.MetaDescription;
                _projectManager.Update(_saveData);
                _projectManager.Save();
                if (model.FileCollection != null && model.FileCollection.Count > 0)
                    UploadFile.UploadProjectImage(model.FileCollection, _saveData.Alias, _saveData.Id.ToString());
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