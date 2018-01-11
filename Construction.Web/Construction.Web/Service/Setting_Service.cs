using Construction.Domain.Core;
using Construction.Domain.Models;
using Construction.Web.Areas.Admin.Models.Setting;
using Construction.Web.Common;
using Construction.Web.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Construction.Web.Service
{
    public class Setting_Service : BaseService
    {
        private readonly DataBaseManager<Setting> _settingManager;
        public Setting_Service()
        {
            this._settingManager = DataBaseManager<Setting>.Create();
        }
        public Result<List<Setting>> GetSettings(Page page)
        {
            var listData = _settingManager.GetAll(page, p => p.Id);
            if (listData != null && listData.Results != null && listData.Results.Count > 0)
            {
                for (int i = 0; i < listData.Results.Count; i++)
                {

                    listData.Results[i].Name = listData.Results[i].Type.GetByEnumByName<SETTINGTYPE>().DisplayName();
                }
            }
            return listData;
        }

        public SettingCrudViewModel Find(int id)
        {
            var _data = _settingManager.GetById(id);
            var model = new SettingCrudViewModel();
            model.Id = _data.Id;
            model.Type = _data.Type;
            model.Name = _data.Name;
            model.Description = WebUtility.HtmlDecode(_data.Description);
            return model;
        }
        public int CreateSetting(SettingCrudViewModel model)
        {
            try
            {
                var _saveData = new Setting();
                _saveData.Type = model.Type;
                _saveData.Name = model.Name;
                _saveData.Description = WebUtility.HtmlEncode(model.Description);
                _settingManager.Add(_saveData);
                _settingManager.Save();
                return _saveData.Id;
            }
            catch (Exception ex)
            {

                return 0;
            }

        }
        public int UpdateSetting(SettingCrudViewModel model)
        {
            try
            {
                var _saveData = new Setting();
                _saveData = _settingManager.GetById(model.Id);
                _saveData.Type = model.Type;
                _saveData.Name = model.Name;
                _saveData.Description = WebUtility.HtmlEncode(model.Description);
                _settingManager.Update(_saveData);
                _settingManager.Save();
                return _saveData.Id;
            }
            catch (Exception ex)
            {

                return 0;
            }

        }
    }
}