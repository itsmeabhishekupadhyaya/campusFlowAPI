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
}
}
