using Embrace.API.DTOs;
using Embrace.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Embrace.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcaoSolidariaController : ControllerBase
    {
        private readonly AcaoSolidariaService _service;

        public AcaoSolidariaController(AcaoSolidariaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var acoes = await _service.GetAllAsync();
            return Ok(acoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var acao = await _service.GetByIdAsync(id);
            return acao == null ? NotFound() : Ok(acao);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AcaoSolidariaDTO dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] AcaoSolidariaDTO dto)
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