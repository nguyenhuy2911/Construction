using Construction.Domain.Models.AspIdentityUser;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construction.Domain.Core
{
    public class ApplicationUserDbContext : IdentityDbContext<User, Role, string, UserLogin, UserRole, UserClaim>
    {
        private static ApplicationUserDbContext _applicationUserContext;
        public ApplicationUserDbContext() : base("DatabaseContext")
        {
        }

        public static ApplicationUserDbContext Create()
        {
            return _applicationUserContext ?? (_applicationUserContext = new ApplicationUserDbContext());
        }
    }
}
