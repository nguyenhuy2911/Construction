using Construction.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction.Web.Common.Extensions
{
    public static class PagingExtensions
    {
      
        public static IQueryable<T> GetPage<T>(this IQueryable<T> queryable, Page page)
        {
            return queryable.Skip(page.Skip).Take(page.PageSize);
        }
    }

}