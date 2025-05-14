using Microsoft.AspNetCore.Mvc;
using GerirAluguel.Services;
using GerirAluguel.DTO;

namespace GerirAluguel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquilinoController : ControllerBase
    {
        private readonly InquilinoServices _service;

        public InquilinoController(InquilinoServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inquilinos = await _service.GetAll();
            return Ok(inquilinos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var inquilino = await _service.GetOneById(id);

            if (inquilino == null)
                return NotFound("Inquilino não encontrado");

            return Ok(inquilino);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InquilinoDto dto)
        {
            var inquilino = await _service.Create(dto);

            if (inquilino == null)
                return Problem("Erro ao criar inquilino");

            return Created("", inquilino);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] InquilinoDto dto)
        {
            var inquilino = await _service.Update(id, dto);

            if (inquilino == null)
                return NotFound("Inquilino não encontrado");

            return Ok(inquilino);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _service.Delete(id);

            if (!sucesso)
                return NotFound("Inquilino não encontrado");

            return NoContent();
        }
    }
}
