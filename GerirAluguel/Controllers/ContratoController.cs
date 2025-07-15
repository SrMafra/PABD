using Microsoft.AspNetCore.Mvc;
using GerirAluguel.Services;
using GerirAluguel.Dto;
using GerirAluguel.Models;

namespace GerirAluguel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratoController : ControllerBase
    {
        private readonly ContratoServices _service;

        public ContratoController(ContratoServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contratos = await _service.GetAll();
            return Ok(contratos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contrato = await _service.GetOneById(id);
            return contrato is null
                ? NotFound("Contrato não encontrado.")
                : Ok(contrato);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContratoDto dto)
        {
            var contrato = await _service.Create(dto);
            return contrato is null
                ? Problem("Erro ao criar contrato.", statusCode: 500)
                : CreatedAtAction(nameof(GetById), new { id = contrato.ContratoId }, contrato);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContratoDto dto)
        {
            var contrato = await _service.Update(id, dto);
            return contrato is null
                ? NotFound("Contrato não encontrado para atualização.")
                : Ok(contrato);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _service.Delete(id);
            return sucesso
                ? NoContent()
                : NotFound("Contrato não encontrado para exclusão.");
        }
    }
}