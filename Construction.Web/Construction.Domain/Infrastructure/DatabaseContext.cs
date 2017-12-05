using Construction.Domain.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace Construction.Domain.Infrastructure
{
    public partial class DatabaseContext : DbContext
    {
        static DatabaseContext()
        {
            Database.SetInitializer(new DataContextDBInitializer());
        }

        public DatabaseContext(): base("Name=DatabaseContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Category> Product_Category { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
        }
    }
}
