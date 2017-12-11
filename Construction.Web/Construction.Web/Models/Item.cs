using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Construction.Web.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }
      
        public string Thumbnail { get; set; }
       
        public string ShortDescription { get; set; }
       
        public string Description { get; set; }
        
        public string Alias { get; set; }
        public string Action { get; set; }


    }
}