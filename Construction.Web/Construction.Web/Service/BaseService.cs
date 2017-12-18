using Autofac.Util;
using Construction.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Construction.Web.Service
{
    public class BaseService: Disposable
    {
        public UrlHelper Url = new UrlHelper(HttpContext.Current.Request.RequestContext);
    }
}