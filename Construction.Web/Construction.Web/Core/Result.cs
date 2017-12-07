using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction.Web.Core
{
    public class Result<T>
    {
        public Result()
        {
            TotalRow = 0;
            StatusCode = -1;
        }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public T Results { get; set; }
        public int TotalRow { get; set; }
    }
}