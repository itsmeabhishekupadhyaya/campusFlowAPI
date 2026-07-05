using CampusFlow.StudentService.API.Contracts.Requests;
using CampusFlow.StudentService.API.Contracts.Responses;
using CampusFlow.StudentService.API.Contracts.Responses.Student;
using CampusFlow.StudentService.API.Services;
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

    [HttpPost]
    public async Task<IActionResult> CreateStudent(CreateStudentRequest request)
    {
      var response =  await _studentService.CreateStudentAsync(request);
        return CreatedAtAction(nameof(GetStudentById), new { id = response.ID }, response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetStudentById(Guid id)
    {
        return Ok();
    }
}


