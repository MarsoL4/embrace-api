using Embrace.API.DTOs;
using Embrace.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Embrace.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoluntarioController : ControllerBase
    {
        private readonly VoluntarioService _service;

        public VoluntarioController(VoluntarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var voluntarios = await _service.GetAllAsync();
            return Ok(voluntarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var voluntario = await _service.GetByIdAsync(id);
            return voluntario == null ? NotFound() : Ok(voluntario);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VoluntarioDTO dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] VoluntarioDTO dto)
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