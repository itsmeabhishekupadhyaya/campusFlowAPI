using CampusFlow.StudentService.API.Contracts.Common;
using CampusFlow.StudentService.API.Contracts.Requests;
using CampusFlow.StudentService.API.Contracts.Requests.Student;
using CampusFlow.StudentService.API.Contracts.Responses.Student;
using CampusFlow.StudentService.API.Domain.Entities;
using CampusFlow.StudentService.API.Mappings;
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
        return StudentMapper.ToCreateStudentResponse(student);
    }

    

    public async Task<StudentResponse?> GetStudentByIdAsync(Guid Id)
    {

        var student = await _studentRepository.GetStudentByIdAsync(Id);
        if(student is null)
        {
            return null;
        }
        return StudentMapper.ToStudentResponse(student);

    }

  

    public async Task<StudentListResponse> GetStudentsAsync(GetStudentsRequest request)
    {
        var students = await _studentRepository.GetStudentsAsync(request.Page,request.PageSize,request.Search,
             request.SortBy, request.SortDirection);

        var totalRecords = await _studentRepository.CountAsync(request.Search);
        var items = students.Select(StudentMapper.ToStudentResponse).ToList();
      

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

    public async Task<StudentResponse?> UpdateStudentAsync(UpdateStudentRequest request, Guid id)
    {
       var student = await _studentRepository.GetForUpdateAsync(id);
        if (student is null)
        {
            return null;
        }
        student.FirstName = request.FirstName;
        student.LastName = request.LastName;
        student.DateOfBirth = request.DateOfBirth;
        student.MobileNumber = request.MobileNumber;
        student.Gender = request.Gender;
        student.Address = request.Address;
        student.ClassId = request.ClassId;
        student.Email = request.Email;
        student.UpdatedOn = DateTime.UtcNow;

        await _studentRepository.SaveChangesAsync();
        var updatedStudent = await _studentRepository.GetStudentByIdAsync(id);
        return StudentMapper.ToStudentResponse(updatedStudent);
    }

    public async Task<bool> DeleteStudentAsync(Guid id)
    {
        var student = await _studentRepository.GetForUpdateAsync(id);
        if (student == null || student.IsDeleted)
        { 
            return false;
        }
        student.IsDeleted = true;
        student.UpdatedOn = DateTime.UtcNow;
        student.DeletedOn = DateTime.UtcNow;

        await _studentRepository.SaveChangesAsync();
        return true;
    }
}
