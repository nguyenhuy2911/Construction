using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Construction.Domain.Models
{
    public class BaseModel
    {
        public virtual int Id { get; set; }

        [MaxLength(100)]
        public virtual string Name { get; set; }

        [MaxLength(50)]
        public virtual string Thumbnail { get; set; }

        [MaxLength(50)]
        public string CreateBy { get; set; }
        public Nullable<DateTime> CreateDate { get; set; }

        [MaxLength(50)]
        public string EditBy { get; set; }
        public Nullable<DateTime> EditDate { get; set; }

        public int Status { get; set; }

        [AllowHtml]
        public string ShortDescription { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        [MaxLength(50)]
        public string Alias { get; set; }

        [MaxLength(250)]
        public string MetaKeyWord { get; set; }

        public string MetaDescription { get; set; }
    }
}
