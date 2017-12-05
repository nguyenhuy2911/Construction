using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Construction.Domain.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Product_Category = new List<Product_Category>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Alias { get; set; }
        public Nullable<int> Level { get; set; }
        public Nullable<bool> Approve { get; set; }
        public virtual ICollection<Product_Category> Product_Category { get; set; }
    }
}
