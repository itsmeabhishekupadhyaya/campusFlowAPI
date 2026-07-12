using CampusFlow.StudentService.API.Contracts.Common.Enums;

namespace CampusFlow.StudentService.API.Contracts.Requests.Student
{
    public class GetStudentsRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Search { get; set; }
        public string SortBy { get; set; } = "FirstName";
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
    }
}
