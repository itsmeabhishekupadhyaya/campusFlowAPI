using CampusFlow.StudentService.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusFlow.StudentService.API.Persistence.Configurations
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");

            builder.HasKey(c => c.Id);

            builder.HasData(
                new Class
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Grade 1"
                },
                new Class
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Grade 2"
                },
                new Class
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Grade 3"
                }
            );
        }
    }
}
