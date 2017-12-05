using System;
using System.Collections.Generic;

namespace Construction.Domain.Models
{
    public partial class Product_Category
    {
        public int Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
