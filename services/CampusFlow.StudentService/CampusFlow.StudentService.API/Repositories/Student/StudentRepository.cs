
using CampusFlow.StudentService.API.Contracts.Common.Enums;
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
        await _DbContext.Students
                    .AddAsync(student);
        return student;
    }

    public async Task<int> CountAsync(string? search)
    {
       var query = BuildStudentQuery(search);
        return await query.CountAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(Guid id)
    {
        return await _DbContext.Students
            .Include(student => student.Class)
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IReadOnlyList<Student>> GetStudentsAsync(int page, int Pagesize, string? search, string sortBy, SortDirection sortDirection)
    {
        var query = BuildStudentQuery(search);

        query = sortDirection == SortDirection.Descending
            ? query.OrderByDescending(student => student.FirstName)
            : query.OrderBy(student => student.FirstName);

        query = query
            .Skip((page - 1) * Pagesize)
            .Take(Pagesize);

        return await query.ToListAsync();
    }
    

    public async Task SaveChangesAsync()
    {
        await _DbContext.SaveChangesAsync();
    }

    public IQueryable<Student> BuildStudentQuery(string? search)
    {

        IQueryable<Student> query = _DbContext.Students
                                   .Include(student => student.Class)
                                   .AsNoTracking();
        //Allow to search by first name, last name, or email
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(s => s.FirstName.ToLower().Contains(search) || s.LastName.ToLower().Contains(search) || s.Email.ToLower().Contains(search));
        }
        return query;
    }

    public async Task<Student?> GetForUpdateAsync(Guid id)
    {
        return await _DbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
    }
}

