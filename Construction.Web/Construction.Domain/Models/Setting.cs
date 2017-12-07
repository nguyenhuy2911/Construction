using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Construction.Domain.Models
{
    public partial class Setting :BaseModel
    {

        [MaxLength(10)]
        public string Type { get; set; }
    }
}
