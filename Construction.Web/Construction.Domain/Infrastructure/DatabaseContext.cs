using Construction.Domain.Models;
using System;
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
        public virtual void Commit()
        {
            base.SaveChanges();
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
