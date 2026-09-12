using CampusFlow.StudentService.API.Contracts.Requests.Class;
using CampusFlow.StudentService.API.Contracts.Requests.Student;
using CampusFlow.StudentService.API.Contracts.Responses.Class;
using CampusFlow.StudentService.API.Contracts.Responses.Student;
using CampusFlow.StudentService.API.Services.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampusFlow.StudentService.API.Controllers.Class
{
    [Route("api/v1/classes")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        /// <summary>
        /// Retrieves a paginated list of classes.
        /// </summary>
        /// <param name="request">Search, sorting and pagination parameters.</param>
        /// <returns>Paginated list of classes.</returns>
        [HttpGet]
        public async Task<ActionResult<ClassListResponse>> GetClasses([FromQuery] GetClassesRequest request)
        {
            var response = await _classService.GetClassesAsync(request);
            return Ok(response);
        }
    }
}
