using Construction.Domain.Core;
using Construction.Domain.Models;
using System.Collections.Generic;

namespace Construction.Web.Models
{
    public class Project_ItemsViewModel
    {
        public Pagination<Item> Data { get; set; }
        
    }
}