using Construction.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction.Web.Models.Navigation
{
    public class NavigationViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Construction.Domain.Models.Service> ListService { get; set; }
    }
}