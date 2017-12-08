using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Construction.Domain.Helper
{
    public static class Helper
    {
        public static string GetDisplayName(this object value)
        {
            return value.GetType().GetMember(value.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .Name;
        }
    }
}