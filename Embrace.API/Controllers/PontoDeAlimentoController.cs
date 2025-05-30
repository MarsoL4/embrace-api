using Embrace.API.DTOs;
using Embrace.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Embrace.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PontoDeAlimentoController : ControllerBase
    {
        private readonly PontoDeAlimentoService _service;

        public PontoDeAlimentoController(PontoDeAlimentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pontos = await _service.GetAllAsync();
            return Ok(pontos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var ponto = await _service.GetByIdAsync(id);
            return ponto == null ? NotFound() : Ok(ponto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PontoDeAlimentoDTO dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] PontoDeAlimentoDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID da rota e do corpo não coincidem.");

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