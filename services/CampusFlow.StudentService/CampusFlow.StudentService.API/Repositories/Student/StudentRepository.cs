
using CampusFlow.StudentService.API.Contracts.Common.Enums;
using CampusFlow.StudentService.API.Contracts.Constants;
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
        query = ApplySorting(query,sortBy,sortDirection);

    query = ApplyPaging(query, page, Pagesize);

       

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

    private IQueryable<Student> ApplySorting(
    IQueryable<Student> query,
    string sortBy,
    SortDirection sortDirection)
    {
        var descending = sortDirection == SortDirection.Descending;

        return sortBy.ToLower() switch
        {
           StudentSortFields.FirstName => descending
                ? query.OrderByDescending(x => x.FirstName)
                : query.OrderBy(x => x.FirstName),

            StudentSortFields.Email => descending
                ? query.OrderByDescending(x => x.Email)
                : query.OrderBy(x => x.Email),

            StudentSortFields.Mobile => descending
                ? query.OrderByDescending(x => x.MobileNumber)
                : query.OrderBy(x => x.MobileNumber),

            StudentSortFields.Gender => descending
                ? query.OrderByDescending(x => x.Gender)
                : query.OrderBy(x => x.Gender),

            StudentSortFields.Class => descending
                ? query.OrderByDescending(x => x.Class.Name)
                : query.OrderBy(x => x.Class.Name),


            _ => descending
                ? query.OrderByDescending(x => x.FirstName)
                : query.OrderBy(x => x.FirstName),
        };
    }

    private static IQueryable<Student> ApplyPaging(
    IQueryable<Student> query,
    int page,
    int pageSize)
    {
        return query
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
    }
}

