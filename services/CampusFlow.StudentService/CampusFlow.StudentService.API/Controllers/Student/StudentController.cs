using CampusFlow.StudentService.API.Contracts.Requests.Student;
using CampusFlow.StudentService.API.Contracts.Responses.Student;
using CampusFlow.StudentService.API.Services.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampusFlow.StudentService.API.Controllers.Student;

    [Route("api/v1/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
            public StudentController(IStudentService studentService)
            {
                _studentService = studentService;
            }

        [HttpGet]
        public ActionResult<StudentListResponse> GetStudents([FromQuery] GetStudentsRequest request)
        {

        var response = _studentService.GetStudents(request);

        return Ok(response);

        }
     }


