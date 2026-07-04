namespace CampusFlow.StudentService.API.Contracts.Requests.Student
{
    public class GetStudentsRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Search { get; set; }
        public string SortBy { get; set; } = "FirstName";
        public string SortOrder { get; set; } = "Asc";
    }
}
