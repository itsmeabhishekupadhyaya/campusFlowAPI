using CampusFlow.StudentService.API.Contracts.Responses.Class;
using CampusFlow.StudentService.API.Contracts.Responses.Student;
using CampusFlow.StudentService.API.Domain.Entities;

namespace CampusFlow.StudentService.API.Mappings
{
    public class ClassMapper
    {
        public static ClassResponse ToClassResponse(Class response)
        {
            return new ClassResponse
            {
                Id = response.Id,
                Name = response.Name,
             
            };
        }
    


               

    
    }
}
