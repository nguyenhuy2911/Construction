using Construction.Domain.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace Construction.Domain.Infrastructure
{
    public partial class DatabaseContext : DbContext
    {
        private static DatabaseContext _dataContext;
        static DatabaseContext()
        {
            Database.SetInitializer(new DataContextDBInitializer());
        }

        public DatabaseContext(): base("Name=DatabaseContext")
        {
        }

        public static DatabaseContext Create()
        {
            return _dataContext ?? (_dataContext = new DatabaseContext());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
        }
    }
}
