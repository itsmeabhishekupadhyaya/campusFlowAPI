using CampusFlow.StudentService.API.Contracts.Requests.Class;
using CampusFlow.StudentService.API.Contracts.Requests.Student;
using CampusFlow.StudentService.API.Contracts.Responses.Class;
using CampusFlow.StudentService.API.Contracts.Responses.Student;

namespace CampusFlow.StudentService.API.Services.Class
{
    public interface IClassService
    {
        Task<ClassListResponse> GetClassesAsync(GetClassesRequest request);
    }
}
