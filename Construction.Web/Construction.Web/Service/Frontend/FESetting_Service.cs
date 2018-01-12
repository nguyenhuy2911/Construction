using Construction.Domain.Core;
using Construction.Domain.Models;
using Construction.Web.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction.Web.Service.Frontend
{
    public class FESetting_Service: BaseService
    {
        private readonly DataBaseManager<Setting> _settingManager;
        public FESetting_Service()
        {
            _settingManager = DataBaseManager<Setting>.Create();
        }

        public Setting GetAboutPage()
        {
            var data = _settingManager.GetPage(new Page(0, 10), p => p.Type == SETTINGTYPE.ABOUT.ToString(), p
                   => p.Id)?.Results?.FirstOrDefault();
            return data;
        }
        public Setting GetContactPage()
        {
            var data = _settingManager.GetPage(new Page(0, 10), p => p.Type == SETTINGTYPE.CONTACT.ToString(), p
                   => p.Id)?.Results?.FirstOrDefault();
            return data;
        }
        public Setting GetServiceContent()
        {
            var data = _settingManager.GetPage(new Page(0, 10), p => p.Type == SETTINGTYPE.SERVICE.ToString(), p
                   => p.Id)?.Results?.FirstOrDefault();
            return data;
        }
    }
}