using CampusFlow.StudentService.API.Contracts.Requests.Class;
using CampusFlow.StudentService.API.Contracts.Responses.Class;
using CampusFlow.StudentService.API.Mappings;
using CampusFlow.StudentService.API.Repositories.Class;

namespace CampusFlow.StudentService.API.Services.Class
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;



        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<ClassListResponse> GetClassesAsync(GetClassesRequest request)
        {
            var classes = await _classRepository.GetClassesAsync(request.Page, request.PageSize, request.Search,
                 request.SortBy, request.SortDirection);

            var totalRecords = await _classRepository.CountAsync(request.Search);
            var items = classes.Select(ClassMapper.ToClassResponse).ToList();


            var totalPages = (int)Math.Ceiling(
        (double)totalRecords / request.PageSize);

            return new ClassListResponse
            {
                Items = items,

                TotalRecords = totalRecords,
                TotalPages = totalPages,
                Page = request.Page,
                PageSize = request.PageSize
            };

        }

     
    }
}
