using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolBooks.Services.DTO.Pupils;
using SchoolBooks.Services.DTO.SchoolBook;
using SchoolBooks.Services.Interfaces;

namespace SchoolBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PupilController : Controller
    {
        private readonly IPupilService<PupilsDtoRead,PupilDtoRegistration> _pupilService;
        public PupilController(IPupilService<PupilsDtoRead, PupilDtoRegistration> pupilService)
        {
            _pupilService = pupilService;
        }
        [HttpGet("GetAllBooksOfCertainPupil")]
        public async Task<IActionResult> Get([FromQuery] string pupilId)
        {
            try
            {
                ICollection<SchoolBookDTORead> data = await _pupilService.GetAllBooksOfPupil(pupilId);
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
        [HttpPost("AddBookToPupil")]
        public async Task<IActionResult> AddABookToPupil([FromQuery] string pupilId, [FromBody]SchoolBookDtoWrite dto)
        {
            try
            {
                await _pupilService.AddBookToPupil(pupilId, dto);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
