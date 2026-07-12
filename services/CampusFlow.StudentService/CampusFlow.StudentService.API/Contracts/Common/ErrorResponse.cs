namespace CampusFlow.StudentService.API.Contracts.Common;

public class ErrorResponse
{
    public string Code { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public string TraceId { get; set; } = string.Empty;

    public IReadOnlyList<ValidationError> Errors { get; set; } = [];
}
