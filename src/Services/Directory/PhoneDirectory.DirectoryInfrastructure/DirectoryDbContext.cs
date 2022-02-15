using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhoneDirectory.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneDirectory.DirectoryInfrastructure
{
    public class DirectoryDbContext : DbContext
    {

        public DirectoryDbContext(DbContextOptions<DirectoryDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var AddedEntities = ChangeTracker.Entries().Where(E => E.Entity is IEntity && E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("CreatedAt").CurrentValue = DateTime.Now;
                E.Property("UpdatedAt").CurrentValue = DateTime.Now;

            });

            var EditedEntities = ChangeTracker.Entries().Where(E => E.Entity is IEntity && E.State == EntityState.Modified).ToList();

            EditedEntities.ForEach(E =>
            {
                E.Property("UpdatedAt").CurrentValue = DateTime.Now;
            });
            return base.SaveChangesAsync(cancellationToken);
        }
      
    }
}
