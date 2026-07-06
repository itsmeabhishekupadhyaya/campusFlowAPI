using CampusFlow.StudentService.API.Contracts.Requests;
using CampusFlow.StudentService.API.Contracts.Requests.Student;
using CampusFlow.StudentService.API.Contracts.Responses.Student;


namespace CampusFlow.StudentService.API.Services;

    public interface IStudentService
    {
        Task<CreateStudentResponse> CreateStudentAsync(CreateStudentRequest request);
        Task<StudentListResponse> GetStudentsAsync(GetStudentsRequest request);
        Task<StudentResponse?> GetStudentByIdAsync(Guid Id);
        Task<StudentResponse?> UpdateStudentAsync(UpdateStudentRequest request, Guid Id);
    }

