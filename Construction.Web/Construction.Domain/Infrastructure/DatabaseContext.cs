using Construction.Domain.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace Construction.Domain.Infrastructure
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(): base("Name=DatabaseContext")
        {
            Database.SetInitializer(new DataContextDBInitializer());
         //   Database.SetInitializer<DatabaseContext>(null);
            this.Configuration.LazyLoadingEnabled = true;
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
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
        }
    }
}
