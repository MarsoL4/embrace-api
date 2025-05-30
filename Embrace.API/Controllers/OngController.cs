using Embrace.API.DTOs;
using Embrace.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Embrace.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OngController : ControllerBase
    {
        private readonly OngService _service;

        public OngController(OngService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ongs = await _service.GetAllAsync();
            return Ok(ongs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var ong = await _service.GetByIdAsync(id);
            return ong == null ? NotFound() : Ok(ong);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OngDTO dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] OngDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID do corpo e da rota não coincidem.");

            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}