using CampusFlow.StudentService.API.Domain.Enums;

namespace CampusFlow.StudentService.API.Contracts.Responses.Student;

public class StudentResponse
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;

    public Guid ClassId { get; set; }

    public string ClassName { get; set; } = string.Empty;

    public GenderType Gender { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string Status { get; set; } = string.Empty;
}
