using CampusFlow.StudentService.API.Contracts.Requests.Student;
using CampusFlow.StudentService.API.Contracts.Responses.Student;

namespace CampusFlow.StudentService.API.Repositories.Student
{
    public interface IStudentRepository
    {
        StudentListResponse GetStudents(GetStudentsRequest request);
    }
}
