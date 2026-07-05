using CampusFlow.StudentService.API.Contracts.Requests.Student;
using CampusFlow.StudentService.API.Contracts.Responses.Student;

namespace CampusFlow.StudentService.API.Repositories.Student
{
    public class StudentRepository : IStudentRepository
    {
       
        public StudentListResponse GetStudents(GetStudentsRequest request)
        {
             return new StudentListResponse
             {
                 Items =
             [
                 new StudentResponse
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "Jhon.Doe@gmail.com",
                        MobileNumber = "1234567890",
                        ClassId = Guid.NewGuid(),
                        ClassName = "Class A",
                        Gender = "Male",
                        DateOfBirth = new DateOnly(1990, 10, 1),
                        Address= "123 Main St, City, Country",
                        Status= "Active"
                    },
                    new StudentResponse
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Abhishek",
                        LastName = "Upadhyaya",
                        Email = "abhishek.upadhyaya23@gmail.com",
                        MobileNumber = "9871001204",
                        ClassId = Guid.NewGuid(),
                        ClassName = "Class B",
                        Gender = "Male",
                        DateOfBirth = new DateOnly(1990, 10, 23),
                        Address= "123 Main St, City, Country",
                        Status= "Active"
                    }
                 ],
                 Page = request.Page,
                 PageSize = request.PageSize,
                 TotalRecords = 2,
                 TotalPages = 1
             };
        }
    }
}
