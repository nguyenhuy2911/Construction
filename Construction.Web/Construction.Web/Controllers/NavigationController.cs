﻿using Construction.Web.Models.Navigation;
using Construction.Web.Service.Fronend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Construction.Web.Controllers
{
    public class NavigationController : Controller
    {
        private Navigation_Service _navService { get; set; }
        public NavigationController()
        {
            this._navService = new Navigation_Service();
        }

        public ActionResult NaviBar()
        {
            var model = new NavigationViewModel();
            model = _navService.GetNavigationViewModel();
            return View(model);
        }
    }
}