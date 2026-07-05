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

    public async Task<CreateStudentResponse> CreateStudentAsync(CreateStudentRequest request)
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
        return new CreateStudentResponse
        {
            ID = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            MobileNumber = student.MobileNumber,
            DateOfBirth = student.DateOfBirth,
            Gender = student.Gender,
            Address = student.Address,
            ClassId = student.ClassId

        };

    //public async Task<ICollection<StudentResponse>> GetStudentsAsync(GetStudentsRequest request)
    //{
    //    var 
    //    await _studentRepository.GetStudentsAsync(request);
    //}
}

    public async Task<StudentResponse?> GetStudentByIdAsync(Guid Id)
    {

        var student = await _studentRepository.GetStudentByIdAsync(Id);
        if(student is null)
        {
            return null;
        }
        return new StudentResponse
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            DateOfBirth = student.DateOfBirth,
            MobileNumber = student.MobileNumber,
            Gender = student.Gender,
            Address = student.Address,
            ClassId = student.ClassId
        };
       
    }

  

    public async Task<StudentListResponse> GetStudentsAsync(GetStudentsRequest request)
    {
        var students = await _studentRepository.GetStudentsAsync(request.Page,request.PageSize,request.Search,
             request.SortBy, request.SortDirection);

        var totalRecords = await _studentRepository.CountAsync(request.Search);
        var items =  students.Select(student => new StudentResponse
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            MobileNumber = student.MobileNumber,
            DateOfBirth = student.DateOfBirth,
            Gender = student.Gender,
            ClassId = student.ClassId,
            Address = student.Address,
        }).ToList();

        var totalPages = (int)Math.Ceiling(
    (double)totalRecords / request.PageSize);

        return new StudentListResponse
        {
            Items = items,
            
            TotalRecords = totalRecords,
            TotalPages = totalPages,
            Page = request.Page,
            PageSize = request.PageSize
        };

    }
}
