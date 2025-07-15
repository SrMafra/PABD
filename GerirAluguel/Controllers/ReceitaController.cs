using GerirAluguel.DTO;
using GerirAluguel.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ReceitaController : ControllerBase
{
    private readonly ReceitaServices _service;

    public ReceitaController(ReceitaServices service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var receitas = await _service.GetAll();
        return Ok(receitas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var receita = await _service.GetById(id);
        return receita is null
            ? NotFound($"Receita com ID {id} não encontrada.")
            : Ok(receita);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ReceitaDto dto)
    {
        var receita = await _service.Create(dto);
        return receita is null
            ? Problem("Erro ao criar receita. Verifique os dados informados.", statusCode: 500)
            : CreatedAtAction(nameof(GetById), new { id = receita.ReceitaId }, receita);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ReceitaDto dto)
    {
        var receita = await _service.Update(id, dto);
        return receita is null
            ? NotFound($"Não foi possível atualizar. Receita com ID {id} não encontrada.")
            : Ok(receita);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var sucesso = await _service.Delete(id);
        return sucesso
            ? NoContent()
            : NotFound($"Não foi possível excluir. Receita com ID {id} não encontrada.");
    }
}