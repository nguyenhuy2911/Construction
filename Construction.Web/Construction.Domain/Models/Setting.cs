using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Construction.Domain.Models
{
    public partial class Setting
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
