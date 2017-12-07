using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Construction.Domain.Models
{
    public partial class Product :BaseModel
    {
        public Product()
        {
           
        }
       
        [MaxLength(20)]
        public string Code { get; set; }

        [MaxLength(50)]
        public string Link { get; set; }

 
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public int ServiceId { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
    }
}
