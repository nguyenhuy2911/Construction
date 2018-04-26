using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Construction.Domain.Models
{
    [Table("Setting")]
    public partial class Setting :BaseModel
    {

        [MaxLength(10)]
        public string Type { get; set; }
    }
}
