using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolBooks.Services.DTO.Pupils;
using SchoolBooks.Services.DTO.SchoolBook;
using SchoolBooks.Services.Interfaces;

namespace SchoolBooks.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : Controller
    {
        private readonly ISchoolService<SchoolBookDTORead,SchoolBookDtoWrite> _service;

        public SchoolController(ISchoolService<SchoolBookDTORead, SchoolBookDtoWrite> service)
        {
            _service = service;
        }

        [HttpGet("GetAllPupilsBySchoolName")]
        public async Task<IActionResult> Get([FromQuery] string schoolname)
        {
            try
            {
               ICollection<PupilsDtoRead>data=await _service.getAllPupilsOfCertainSchool(schoolname);
                if (data == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                return StatusCode(StatusCodes.Status200OK, data);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
