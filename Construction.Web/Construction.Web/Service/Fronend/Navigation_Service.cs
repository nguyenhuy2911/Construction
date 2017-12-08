using Construction.Domain.Core;
using Construction.Domain.Helper.Enum;
using Construction.Domain.Models;
using Construction.Web.Models.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction.Web.Service.Fronend
{
    public class Navigation_Service : BaseService
    {
        private readonly DataBaseManager<Category> _categoryManager = DataBaseManager<Category>.Create();
        public NavigationViewModel GetNavigationViewModel()
        {
            var model = new NavigationViewModel();
            var _activeCategories = new List<Category>();
            int _activeStatus = (int)ACTIVE_TYPE.ACTIVE;
            _activeCategories = _categoryManager.GetPage(new Page(0, int.MaxValue), p => p.Status == _activeStatus, p => p.Id).Results;
            model.Categories = _activeCategories;
            return model;

        }

    }
}