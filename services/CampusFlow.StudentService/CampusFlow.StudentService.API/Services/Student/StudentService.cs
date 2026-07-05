using CampusFlow.StudentService.API.Contracts.Requests;
using CampusFlow.StudentService.API.Contracts.Requests.Student;
using CampusFlow.StudentService.API.Contracts.Responses.Student;
using CampusFlow.StudentService.API.Domain.Entities;
using CampusFlow.StudentService.API.Repositories;



namespace CampusFlow.StudentService.API.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task CreateStudentAsync(CreateStudentRequest request)
    {
        var student = new Student
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            MobileNumber = request.MobileNumber,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
            Address = request.Address,
            ClassId = request.ClassId
        };

        await _studentRepository.AddAsync(student);

        await _studentRepository.SaveChangesAsync();
    }

    //public async Task<ICollection<StudentResponse>> GetStudentsAsync(GetStudentsRequest request)
    //{
    //    var 
    //    await _studentRepository.GetStudentsAsync(request);
    //}
}
