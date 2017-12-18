using Construction.Domain.Core;
using Construction.Domain.Helper.Enum;
using Construction.Domain.Models;
using Construction.Web.Common;
using Construction.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Construction.Web.Service.FrontEnd
{
    public class FEProject_Service : BaseService
    {
        private readonly DataBaseManager<Project> _projectManager = DataBaseManager<Project>.Create();

        public Project_HomeItemsViewModel GetHomeItems()
        {
            int activeStatus = (int)ACTIVE_TYPE.ACTIVE;
            var items = _projectManager.GetPage(new Page(0, 10), p=>p.Status == activeStatus, p => p.Id)?.Results ?? new List<Project>();
            return new Project_HomeItemsViewModel()
            {
                Items = items
            };
        }

        public Project_Detail_ViewModel GetDetailItem(int id)
        {
            var item = _projectManager.GetById(id);
            item.Link = Url.Project360Url(item.Link);
            return new Project_Detail_ViewModel()
            {
                Item = item
            };
        }

        public Project_ItemsViewModel GetItems(Page page)
        {
            int activeStatus = (int)ACTIVE_TYPE.ACTIVE;
            var pagination = new Pagination<Item>(page.PageNumber, page.PageSize);
            var datas = _projectManager.GetPage(page, p => p.Status == activeStatus, p => p.Id);

            if (datas != null && datas.Results != null && datas.Results.Count > 0)
            {
                pagination.TotalRow = datas.TotalRow;
                pagination.Link = "du-an";
                pagination.Items = datas.Results.Select(p => new Item()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Thumbnail = Url.ProjectImgUrl(p.Thumbnail),
                    ShortDescription = p.ShortDescription,
                    Link = Url.RouteUrl("ProjectDetail", new { alias = p.Alias, id = p.Id })
                }).ToList();
            }
            return new Project_ItemsViewModel()
            {
                Data = pagination
            };
        }

    }
}