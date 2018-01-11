using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Construction.Web.Common
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return System.Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static T GetByEnumByName<T>(this string value)
        {
            var _enum = (T)Enum.Parse(typeof(T), value);
            return _enum;
        }

        public static string DisplayName(this Enum val)
        {
            return val.GetType()
                      .GetMember(val.ToString())
                      .FirstOrDefault()
                      ?.GetCustomAttribute<DisplayAttribute>(false)
                      ?.Name
                      ?? val.ToString();
        }
    }
}