using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construction.Domain.Models
{
    [Table("Service")]
    public class Service : BaseModel
    {
      
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
