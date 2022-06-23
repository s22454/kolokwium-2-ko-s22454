using System.Threading.Tasks;
using kolokwium_2_ko_s22454.Models.DTOs;
using kolokwium_2_ko_s22454.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium_2_ko_s22454.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicianController : ControllerBase
    {
        private readonly IMusicianService _service;

        public MusicianController(IMusicianService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMusician(int id)
        {
            var res = await _service.GetMusician(id);

            if (res is null)
            {
                return NotFound("Nie ma takiego wykonawcy!");
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusician(int id)
        {
            bool res = await _service.DeleteMusician(id);
            if (res)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}