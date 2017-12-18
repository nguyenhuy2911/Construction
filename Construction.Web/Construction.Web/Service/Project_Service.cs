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
using System.Web.Mvc;

namespace Construction.Web.Service
{
    public class Project_Service : BaseService
    {
        private readonly DataBaseManager<Project> _projectManager;
        private readonly DataBaseManager<Category> _categoryManager;
        private readonly DataBaseManager<Construction.Domain.Models.Service> _serviceManager;
        public Project_Service()
        {
            _projectManager = DataBaseManager<Project>.Create();
            _categoryManager = DataBaseManager<Category>.Create();
            _serviceManager = DataBaseManager<Construction.Domain.Models.Service>.Create();
        }
        public Result<List<Project>> GetPojects(Page page)
        {
            try
            {
                var data = _projectManager.GetAll(page, p => p.Id);
                if (data.Results != null && data.Results.Count > 0)
                {
                    var listItem = data.Results.Select(p => new Project
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Alias = p.Alias,
                        Status = p.Status,
                        Thumbnail = Url.ProjectImgUrl(p.Thumbnail),

                    }).ToList();
                    data.Results = listItem;
                }
                return data;
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
            model.ShortDescription = _data.ShortDescription;
            model.Description = _data.Description;
            model.Link = Url.Project360Url(_data.Link);
            model.Thumbnail = Url.ProjectImgUrl(_data.Thumbnail);
            model.MetaKeyWord = _data.MetaKeyWord;
            model.MetaDescription = _data.MetaDescription;
            model.CategoryId = _data.CategoryId;
            model.ListCategory = this.GetCategorySelectList(_data.CategoryId);
            model.ServiceId = _data.ServiceId;
            model.ListService = this.GetServiceSelectList(_data.ServiceId);
            return model;
        }

        private IEnumerable<SelectListItem> GetCategorySelectList(int selectedValue)
        {
            var result = new List<SelectListItem>();
            var data = _categoryManager.GetAll(new Page(0, int.MaxValue), p => p.Id);
            if (data != null && data.Results != null && data.Results.Count > 0)
            {
                result.AddRange(data.Results.Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = p.Name,
                    Selected = p.Id.Equals(selectedValue)
                }).ToList());
            }
            return result;
        }

        private IEnumerable<SelectListItem> GetServiceSelectList(int selectedValue)
        {
            var result = new List<SelectListItem>();
            var data = _serviceManager.GetAll(new Page(0, int.MaxValue), p => p.Id);
            if (data != null && data.Results != null && data.Results.Count > 0)
            {
                result.AddRange(data.Results.Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = p.Name,
                    Selected = p.Id.Equals(selectedValue)
                }).ToList());
            }
            return result;
        }

        public int CreateProject(ProjectCrudViewModel model)
        {
            try
            {
                var _saveData = new Project();
                _saveData.Name = model.Name;
                _saveData.Alias = model.Name.GenerateFriendlyName();
                _saveData.Status = model.Status;
                _saveData.CategoryId = model.CategoryId;
                _saveData.ServiceId = model.ServiceId;
                _saveData.ShortDescription = WebUtility.HtmlEncode(model.ShortDescription);
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

        public Result<Project> UpdateProject(ProjectCrudViewModel model)
        {
            var result = new Result<Project>();
            try
            {
                var _saveData = new Project();
                _saveData = _projectManager.GetById(model.Id);
                _saveData.Name = model.Name;
                _saveData.Alias = model.Name.GenerateFriendlyName();
                _saveData.Status = model.Status;
                _saveData.CategoryId = model.CategoryId;
                _saveData.ServiceId = model.ServiceId;
                _saveData.ShortDescription = WebUtility.HtmlEncode(model.ShortDescription);
                _saveData.Description = WebUtility.HtmlEncode(model.Description);
                _saveData.MetaKeyWord = model.MetaKeyWord;
                _saveData.MetaDescription = model.MetaDescription;
                _projectManager.Update(_saveData);
                _projectManager.Save();
                return result = new Result<Project>()
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

        public Result<Project> UploadImage(ProjectCrudViewModel model)
        {
            var result = new Result<Project>();
            try
            {
                var _saveData = new Project();
                _saveData = _projectManager.GetById(model.Id);
                if (model.FileCollection != null && model.FileCollection.Count > 0)
                {
                    _saveData.Thumbnail = string.Format("{0}/{1}.{2}", _saveData.Id, _saveData.Alias, "png");
                    UploadFile.UploadProjectImage(model.FileCollection, _saveData.Alias, _saveData.Id.ToString());
                }
                _projectManager.Update(_saveData);
                _projectManager.Save();
                return result = new Result<Project>()
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

        public Result<Project> Upload360(ProjectCrudViewModel model)
        {
            var result = new Result<Project>();
            try
            {
                var _saveData = new Project();
                _saveData = _projectManager.GetById(model.Id);
                if (model.File_360 != null && !string.IsNullOrEmpty(model.File_360.FileName))
                {
                    _saveData.Link = string.Format("{0}/{1}.{2}", _saveData.Id.ToString(), _saveData.Alias, "html");
                    UploadFile.UploadProJect360File(model.File_360, _saveData.Alias, _saveData.Id.ToString());
                }
                _projectManager.Update(_saveData);
                _projectManager.Save();
                return result = new Result<Project>()
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