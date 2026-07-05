using CampusFlow.StudentService.API.Domain.Common;
using CampusFlow.StudentService.API.Domain.Enums;

namespace CampusFlow.StudentService.API.Domain.Entities;

public class Student : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string MobileNumber { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }

    public GenderType Gender { get; set; }

    public string? Address { get; set; }

    public Guid ClassId { get; set; }

    public Class Class { get; set; } = null!;
}
