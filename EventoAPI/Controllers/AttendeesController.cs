using Evento.DOMAIN.Core.Entities;
using Evento.DOMAIN.Core.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        private readonly IAttendeesRepository _attendeesRepository;


        public AttendeesController(IAttendeesRepository attendeesRepository)
        {
            _attendeesRepository = attendeesRepository;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var attendeeses = await _attendeesRepository.GetAttendeeses();
            return Ok(attendeeses);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody]Attendees attendees)
        {
            await _attendeesRepository.Insert(attendees);
            return Ok(attendees);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _attendeesRepository.Delete(id);
            if (!result)
                return BadRequest();
            return Ok(result);
        }
        
    }
}
