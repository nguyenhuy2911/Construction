using Construction.Domain.Core;
using Construction.Domain.Models.AspIdentityUser;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace Construction.Domain.Infrastructure
{
    internal class DataContextDBInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            
        }
    }
}
