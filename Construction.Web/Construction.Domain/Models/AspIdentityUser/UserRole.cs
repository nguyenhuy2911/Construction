using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construction.Domain.Models.AspIdentityUser
{
    public class UserRole : IdentityUserRole
    {
        public string Description { get; set; }
    }
}
