using Microsoft.AspNetCore.Mvc;
using GerirAluguel.Services;
using GerirAluguel.DTO;
using GerirAluguel.Models;

namespace GerirAluguel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImovelController : ControllerBase
    {
        private readonly ImovelServices _service;

        public ImovelController(ImovelServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var imoveis = await _service.GetAll();
            return Ok(imoveis);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var imovel = await _service.GetOneById(id);
            return imovel is null
                ? NotFound("Imóvel não encontrado.")
                : Ok(imovel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ImovelDto dto)
        {
            var imovel = await _service.Create(dto);
            return imovel is null
                ? Problem("Erro ao criar imóvel.", statusCode: 500)
                : CreatedAtAction(nameof(GetById), new { id = imovel.ImovelId }, imovel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ImovelDto dto)
        {
            var imovel = await _service.Update(id, dto);
            return imovel is null
                ? NotFound("Imóvel não encontrado para atualização.")
                : Ok(imovel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _service.Delete(id);
            return sucesso
                ? NoContent()
                : NotFound("Imóvel não encontrado para exclusão.");
        }
    }
}