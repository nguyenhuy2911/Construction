using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction.Domain.Core
{
    public class Page
    {

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public Page()
        {
            PageNumber = 0;
            PageSize = 10;
        }

        public Page(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int Skip => PageNumber * PageSize;

    }
}