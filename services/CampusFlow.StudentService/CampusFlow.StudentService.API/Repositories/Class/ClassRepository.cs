using CampusFlow.StudentService.API.Contracts.Common.Enums;
using CampusFlow.StudentService.API.Contracts.Constants;
using CampusFlow.StudentService.API.Domain.Entities;
using CampusFlow.StudentService.API.Persistence;
using Microsoft.EntityFrameworkCore;
using ClassEntity = CampusFlow.StudentService.API.Domain.Entities.Class;

namespace CampusFlow.StudentService.API.Repositories.Class
{
    public class ClassRepository : IClassRepository
    {
        private readonly CampusFlowDbContext _dbContext;

        public ClassRepository(CampusFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<Domain.Entities.Class>> GetClassesAsync(int page, int Pagesize, string? search, string sortBy, SortDirection sortDirection)
        {
            var query = BuildClassQuery(search);
            query = ApplySorting(query, sortBy, sortDirection);
            query = ApplyPaging(query, page, Pagesize);

            return await query.ToListAsync();
            
        }
        public IQueryable<ClassEntity> BuildClassQuery(string? search)
        {

            IQueryable<ClassEntity> query = _dbContext.Classes
                                       .AsNoTracking();
            //Allow to search by name
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                query = query.Where(s => s.Name.ToLower().Contains(search) );
            }
            return query;
        }

        private IQueryable<ClassEntity> ApplySorting(
   IQueryable<ClassEntity> query,
   string sortBy,
   SortDirection sortDirection)
        {
            var descending = sortDirection == SortDirection.Descending;

            return sortBy.ToLower() switch
            {
                ClassSortFields.Name => descending
                     ? query.OrderByDescending(x => x.Name)
                     : query.OrderBy(x => x.Name),

               


                _ => descending
                    ? query.OrderByDescending(x => x.Name)
                    : query.OrderBy(x => x.Name)
            };
        }

        private static IQueryable<ClassEntity> ApplyPaging(
        IQueryable<ClassEntity> query,
        int page,
        int pageSize)
        {
            return query
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public async Task<int> CountAsync(string? search)
        {
            var query = BuildClassQuery(search);
            return await query.CountAsync();
        }

      
    }
}
