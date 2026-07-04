using System.ComponentModel.DataAnnotations;

namespace CampusFlow.StudentService.API.Contracts.Requests.Student;

public class CreateStudentRequest
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Phone]
    [MaxLength(10)]
    public string MobileNumber { get; set; } = string.Empty;

    [Required]
    public Guid ClassId { get; set; }

    [Required]
    public DateOnly DateOfBirth { get; set; }

    [Required]
    public string Gender { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Address { get; set; }
}
