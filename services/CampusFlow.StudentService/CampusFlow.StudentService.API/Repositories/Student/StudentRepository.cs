
using CampusFlow.StudentService.API.Domain.Entities;
using CampusFlow.StudentService.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CampusFlow.StudentService.API.Repositories;
 public class StudentRepository : IStudentRepository
 {
    public readonly CampusFlowDbContext _DbContext;
    public StudentRepository(CampusFlowDbContext dbContext)
    {
        _DbContext = dbContext;
    }
    public async Task<Student> AddAsync(Student student)
        {
        await _DbContext.Students.AddAsync(student);
        return student;
    }

    //public async Task<ICollection<Student>> GetStudentsAsync()
    //{
    //   return await _DbContext.Students.ToListAsync();    
    //}

    public async Task SaveChangesAsync()
    {
        await _DbContext.SaveChangesAsync();
    }

}

