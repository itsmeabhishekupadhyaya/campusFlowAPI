
using CampusFlow.StudentService.API.Contracts.Common.Enums;
using CampusFlow.StudentService.API.Domain.Entities;
namespace CampusFlow.StudentService.API.Repositories;

    public interface IStudentRepository
    {
        Task<Student> AddAsync(Student student);

    Task<IReadOnlyList<Student>> GetStudentsAsync(int page, int Pagesize, string? search, string sortBy, SortDirection sortDirection);

    Task<int> CountAsync(string? search);
                                                        
    Task<Student?> GetStudentByIdAsync(Guid id);
    Task SaveChangesAsync();

    Task<Student?> GetForUpdateAsync(Guid id);

}



