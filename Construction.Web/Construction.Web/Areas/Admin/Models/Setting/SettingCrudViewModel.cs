using Construction.Web.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Construction.Web.Common;
namespace Construction.Web.Areas.Admin.Models.Setting
{
    public class SettingCrudViewModel : Construction.Domain.Models.Setting
    {
        public IEnumerable<SelectListItem> ListSettingType
        {
            get
            {
                var selectList = new List<SelectListItem>();
                var listType = EnumExtensions.GetValues<SETTINGTYPE>();
                foreach (var item in listType)
                {
                    var _selectListItem = new SelectListItem();
                    _selectListItem.Value = item.ToString();
                    _selectListItem.Text = item.DisplayName();
                    _selectListItem.Selected = this.Type == item.ToString();
                    selectList.Add(_selectListItem);
                }
                return selectList;
            }
        }
    }
}