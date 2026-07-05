using CampusFlow.StudentService.API.Contracts.Requests;
using CampusFlow.StudentService.API.Contracts.Requests.Student;
using CampusFlow.StudentService.API.Contracts.Responses.Student;


namespace CampusFlow.StudentService.API.Services;

    public interface IStudentService
    {
      Task CreateStudentAsync(CreateStudentRequest request);
      //Task<ICollection<StudentResponse>> GetStudentsAsync(GetStudentsRequest request);
}

