using ControleFinanceiro.Dtos.Relatorio;
using ControleFinanceiro.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RelatorioController(RelatorioService relatorioService) : ControllerBase
{
    [HttpGet("saldo")]
    public async Task<ActionResult<SaldoResponse>> RetornarSaldo()
    {
        var saldo = await relatorioService.RetornarSaldo();

        return Ok(saldo);
    }

    [HttpGet("resumo")]
    public async Task<ActionResult<SaldoResponse>> RetornaResumo()
    {
        var resumo = await relatorioService.RetornarResumo();

        return Ok(resumo);
    }

    [HttpGet("total-categoria")]
    public async Task<ActionResult<List<TotalPorCategoriaResponse>>> TotalPorCategoria()
    {
        var total = await relatorioService.TotalPorCategoria();

        return Ok(total);
    }
}
