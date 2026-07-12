using CampusFlow.StudentService.API.Contracts.Responses.Student;
using CampusFlow.StudentService.API.Domain.Entities;

namespace CampusFlow.StudentService.API.Mappings;

    public static class StudentMapper
    {
        public static StudentResponse ToStudentResponse(Student student)
        {
            return new StudentResponse
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                MobileNumber = student.MobileNumber,
                ClassId = student.ClassId,
                DateOfBirth = student.DateOfBirth,
                ClassName = student.Class.Name,
                Gender = student.Gender,
                Address = student.Address,
                IsActive = !student.IsDeleted

            };
        }

        public static CreateStudentResponse ToCreateStudentResponse(Student student)
        {
            return new CreateStudentResponse
            {
                ID = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                MobileNumber = student.MobileNumber,
                ClassId = student.ClassId,
                DateOfBirth = student.DateOfBirth,
                Gender = student.Gender,
                Address = student.Address

            };

        }
    }

