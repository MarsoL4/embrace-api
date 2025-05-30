using Embrace.API.DTOs;
using Embrace.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Embrace.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoacaoController : ControllerBase
    {
        private readonly DoacaoService _service;

        public DoacaoController(DoacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doacoes = await _service.GetAllAsync();
            return Ok(doacoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var doacao = await _service.GetByIdAsync(id);
            return doacao == null ? NotFound() : Ok(doacao);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DoacaoDTO dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] DoacaoDTO dto)
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