using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Construction.Domain.Models
{
    public partial class Product
    {
        public Product()
        {
            this.Product_Category = new List<Product_Category>();
        }

        public int Id { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        [MaxLength(50)]
        public string Thumnail { get; set; }

        [MaxLength(50)]
        public string Link { get; set; }
        public Nullable<bool> Approve { get; set; }
        public virtual ICollection<Product_Category> Product_Category { get; set; }
    }
}
