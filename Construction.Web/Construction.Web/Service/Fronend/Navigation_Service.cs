using Construction.Domain.Core;
using Construction.Domain.Helper.Enum;
using Construction.Domain.Models;
using Construction.Web.Models.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction.Web.Service.FrontEnd
{
    public class Navigation_Service : BaseService
    {
        private readonly DataBaseManager<Category> _categoryManager = DataBaseManager<Category>.Create();
        private readonly DataBaseManager<Construction.Domain.Models.Service> _serviceManager = DataBaseManager<Construction.Domain.Models.Service>.Create();
        public NavigationViewModel GetNavigationViewModel()
        {
            var _activedCategories = new List<Category>();
            var _activedListService = new List<Construction.Domain.Models.Service>();
            int _activeStatus = (int)ACTIVE_TYPE.ACTIVE;
            _activedCategories = _categoryManager.GetPage(new Page(0, int.MaxValue), p => p.Status == _activeStatus, p => p.Id).Results;
            _activedListService = _serviceManager.GetPage(new Page(0, int.MaxValue), p => p.Status == _activeStatus, p => p.Id).Results;
            var model = new NavigationViewModel()
            {
                Categories = _activedCategories,
                ListService = _activedListService
            };
            return model;
        }

    }
}