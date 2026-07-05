using CampusFlow.StudentService.API.Contracts.Requests.Student;
using CampusFlow.StudentService.API.Contracts.Responses.Student;

namespace CampusFlow.StudentService.API.Services.Student
{
    public interface IStudentService
    {
        StudentListResponse GetStudents(GetStudentsRequest request);
    }
}
