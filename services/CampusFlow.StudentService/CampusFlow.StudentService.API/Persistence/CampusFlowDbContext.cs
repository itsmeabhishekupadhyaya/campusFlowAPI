using CampusFlow.StudentService.API.Domain.Common;
using CampusFlow.StudentService.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampusFlow.StudentService.API.Persistence
{
    public class CampusFlowDbContext : DbContext
    {
        public CampusFlowDbContext(DbContextOptions<CampusFlowDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Class> Classes => Set<Class>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CampusFlowDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(
    CancellationToken cancellationToken = default)
        {
            ApplyAuditInformation();

            return await base.SaveChangesAsync(cancellationToken);
        }
        private void ApplyAuditInformation()
        {
            var entries = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        entry.Entity.CreatedOn = DateTime.UtcNow;

                        break;

                    case EntityState.Modified:

                        entry.Entity.UpdatedOn = DateTime.UtcNow;

                        break;
                }
            }
        }
    }
}
