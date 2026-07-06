using CampusFlow.StudentService.API.Domain.Enums;

namespace CampusFlow.StudentService.API.Contracts.Responses.Student
{
    public class CreateStudentResponse
    {   
        public  Guid ID { get; set; }
        public string? FirstName { get; set; }
        public string?  LastName { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber  { get; set; }
        public  Guid ClassId { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public GenderType Gender { get; set; }

        public string?  Address  { get; set; }
    }
}
