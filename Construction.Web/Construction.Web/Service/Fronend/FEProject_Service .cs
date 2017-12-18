using Construction.Domain.Core;
using Construction.Domain.Helper.Enum;
using Construction.Domain.Models;
using Construction.Web.Common;
using Construction.Web.Models;
using Construction.Web.Models.Navigation;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;

namespace Construction.Web.Service.FrontEnd
{
    public class FEProject_Service : BaseService
    {
        private readonly DataBaseManager<Project> _projectManager = DataBaseManager<Project>.Create();
        public Project_HomeItemsViewModel GetHomeItems()
        {
            int activeStatus = (int)ACTIVE_TYPE.ACTIVE;
            var items = _projectManager.GetPage(new Page(0, 6), p=>p.Status == activeStatus, p => p.Id)?.Results ?? new List<Project>();
            return new Project_HomeItemsViewModel()
            {
                Items = items
            };
        }

        public IEnumerable<Item> GetRelateItems()
        {
            var items = new List<Item>();
            int activeStatus = (int)ACTIVE_TYPE.ACTIVE;
            var datas = _projectManager.GetPage(new Page(0, 8), p => p.Status == activeStatus, p => Guid.NewGuid());
            if (datas != null && datas.Results != null && datas.Results.Count > 0)
            {
                items = datas.Results.Select(p => new Item()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Thumbnail = Url.ProjectImgUrl(p.Thumbnail),
                    ShortDescription = p.ShortDescription,
                    Link = Url.RouteUrl("ProjectDetail", new { alias = p.Alias, id = p.Id })
                }).ToList();
            }
            return items;
        }

    }
}