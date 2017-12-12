using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction.Web.Models
{
    public class Pagination<T>
    {
        public Pagination(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = PageSize;
        }
        public List<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPage => PageSize > 0 ? TotalRow / PageSize : 0;            
        
        public int TotalRow { get; set; }
        public string Link { get; set; }
    }
}