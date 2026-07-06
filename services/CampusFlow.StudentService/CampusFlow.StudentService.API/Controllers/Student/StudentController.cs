using CampusFlow.StudentService.API.Contracts.Requests;
using CampusFlow.StudentService.API.Contracts.Requests.Student;
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

    /// <summary>
    /// Post Student in Database.
    /// </summary>
    /// <param name="request">Student Details.</param>
    /// <returns>Created Student Deatils</returns>
    [HttpPost]
    public async Task<ActionResult<CreateStudentResponse>> CreateStudent(CreateStudentRequest request)
    {
      var response =  await _studentService.CreateStudentAsync(request);
        return CreatedAtAction(nameof(GetStudentById), new { id = response.ID }, response);
    }

    /// <summary>
    /// Retrieves a paginated list of students.
    /// </summary>
    /// <param name="request">Search, sorting and pagination parameters.</param>
    /// <returns>Paginated list of students.</returns>
    [HttpGet]
    public async Task<ActionResult<StudentListResponse>> GetStudents([FromQuery] GetStudentsRequest request)
    {
        var response = await _studentService.GetStudentsAsync(request);
        return Ok(response);
    }

    /// <summary>
    /// Retrieves details of student.
    /// </summary>
    /// <param name="id">Guid.</param>
    /// <returns>Details of Student.</returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<StudentResponse>> GetStudentById(Guid id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        if(student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }
    /// <summary>
    /// Update deatils of student.
    /// </summary>
    /// <param name="id">Guid.</param>
    /// <returns>Updated Deatil of Student.</returns>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<StudentResponse>> UpdateStudent(UpdateStudentRequest request,  Guid id)
    {
        var student = await _studentService.UpdateStudentAsync(request, id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        var result = await _studentService.DeleteStudentAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}


