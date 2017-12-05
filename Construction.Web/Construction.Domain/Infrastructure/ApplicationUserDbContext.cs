using Construction.Domain.Models.AspIdentityUser;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construction.Domain.Infrastructure
{
    public class ApplicationUserDbContext : IdentityDbContext<User, Role, string, UserLogin, UserRole, UserClaim>
    {
        public ApplicationUserDbContext() : base("DatabaseContext")
        {
        }

        public static ApplicationUserDbContext Create()
        {
            return new ApplicationUserDbContext();
        }
    }
}
