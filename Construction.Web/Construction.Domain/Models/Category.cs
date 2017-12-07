using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Construction.Domain.Models
{
    public partial class Category : BaseModel
    {
        public Category()
        {
            this.Products = new List<Product>();
        }
        public Nullable<int> Level { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
