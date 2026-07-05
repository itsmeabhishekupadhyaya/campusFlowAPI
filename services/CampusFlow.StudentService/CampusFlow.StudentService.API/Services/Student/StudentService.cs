using CampusFlow.StudentService.API.Contracts.Requests.Student;
using CampusFlow.StudentService.API.Contracts.Responses.Student;
using CampusFlow.StudentService.API.Repositories.Student;

namespace CampusFlow.StudentService.API.Services.Student
{
    public class StudentService : IStudentService
    {
        public readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository repository)
        {
            _studentRepository = repository;
        }
        public StudentListResponse GetStudents(GetStudentsRequest request)
        {
            return _studentRepository.GetStudents(request);
        }
    }
}
