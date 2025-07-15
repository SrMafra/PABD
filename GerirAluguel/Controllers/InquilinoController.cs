using Microsoft.AspNetCore.Mvc;
using GerirAluguel.Services;
using GerirAluguel.DTO;

namespace GerirAluguel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> GetById(int id)
        {
            var inquilino = await _service.GetOneById(id);
            return inquilino is null
                ? NotFound("Inquilino não encontrado.")
                : Ok(inquilino);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InquilinoDto dto)
        {
            var inquilino = await _service.Create(dto);
            return inquilino is null
                ? Problem("Erro ao criar inquilino.", statusCode: 500)
                : CreatedAtAction(nameof(GetById), new { id = inquilino.InquilinoId }, inquilino);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InquilinoDto dto)
        {
            var inquilino = await _service.Update(id, dto);
            return inquilino is null
                ? NotFound("Inquilino não encontrado para atualização.")
                : Ok(inquilino);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _service.Delete(id);
            return sucesso
                ? NoContent()
                : NotFound("Inquilino não encontrado para exclusão.");
        }
    }
}