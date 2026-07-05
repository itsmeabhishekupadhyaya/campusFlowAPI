
using CampusFlow.StudentService.API.Domain.Entities;
namespace CampusFlow.StudentService.API.Repositories;

    public interface IStudentRepository
    {
        Task<Student> AddAsync(Student student);

        //Task<ICollection<Student>> GetStudentsAsync();

        Task SaveChangesAsync();

}



