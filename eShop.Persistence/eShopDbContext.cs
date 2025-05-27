using eShop.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Persistence
{
    public class eShopDbContext : DbContext
    {
        public eShopDbContext(DbContextOptions<eShopDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(eShopDbContext).Assembly);
            modelBuilder.Entity<Product>().ToTable("Products");
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now.ToUniversalTime();
                        entry.Entity.CreatedBy = "eShop API";
                        break;

                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
