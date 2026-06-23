using ControleFinanceiro.Dtos.Movimentacao;
using ControleFinanceiro.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimentacaoController(MovimentacaoService movimentacaoService) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<MovimentacaoResponse>> NovaMovimentacao([FromBody] MovimentacaoRequest dto)
    {
        var movimentacao = await movimentacaoService.NovaMovimentacao(dto);

        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = movimentacao.Id },
            movimentacao
        );
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<MovimentacaoResponse>>> ListarCategorias()
    {
        var lista = await movimentacaoService.ListarMovimentacoes();

        if (lista.Count == 0)
        {
            return NoContent();
        }

        return Ok(lista);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<MovimentacaoResponse>> BuscarPorId([FromRoute] int id)
    {
        var movimentacao = await movimentacaoService.BuscarPorId(id);

        if (movimentacao == null)
        {
            return NotFound();
        }

        return Ok(movimentacao);
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeletarPorId([FromRoute] int id)
    {
        var resposta = await movimentacaoService.DeletarPorId(id);

        if (resposta)
        {
            return NoContent();
        }

        return NotFound();
    }
}