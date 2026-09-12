using CampusFlow.StudentService.API.Contracts.Common.Enums;
using ClassEntity = CampusFlow.StudentService.API.Domain.Entities.Class;

namespace CampusFlow.StudentService.API.Repositories.Class
{
    public interface IClassRepository
    {
        Task<IReadOnlyList<ClassEntity>> GetClassesAsync(int page, int Pagesize, string? search, string sortBy, SortDirection sortDirection);
        Task<int> CountAsync(string? search);
    }
}
