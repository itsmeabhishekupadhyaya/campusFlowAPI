using CampusFlow.StudentService.API.Domain.Common;

namespace CampusFlow.StudentService.API.Domain.Entities
{
    public class Class : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Student> students { get; set; } = new List<Student>();
    }
}
