using Microsoft.AspNetCore.Mvc;
using GerirAluguel.Services;
using GerirAluguel.DTO;

namespace GerirAluguel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var Imoveis = await _service.GetAll();
            return Ok(Imoveis);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var Imovel = await _service.GetOneById(id);

            if (Imovel == null)
                return NotFound("Imovel não encontrado");

            return Ok(Imovel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ImovelDto dto)
        {
            var Imovel = await _service.Create(dto);

            if (Imovel == null)
                return Problem("Erro ao criar Imovel");

            return Created("", Imovel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ImovelDto dto)
        {
            var Imovel = await _service.Update(id, dto);

            if (Imovel == null)
                return NotFound("Imovel não encontrado");

            return Ok(Imovel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _service.Delete(id);

            if (!sucesso)
                return NotFound("Imovel não encontrado");

            return NoContent();
        }
    }
}
