using ControleFinanceiro.Dtos.Relatorio;
using ControleFinanceiro.Repositories;

namespace ControleFinanceiro.Services;

public class RelatorioService(
    IMovimentacaoRepository movimentacaoRepository,
    JwtService jwtService
    )
{

    public async Task<SaldoResponse> RetornarSaldo()
    {
        var saldo = await movimentacaoRepository.RetornarSaldo(await jwtService.RetornarUsuarioJwt());

        return new SaldoResponse(saldo);
    }

    public async Task<ResumoResponse> RetornarResumo()
    {
        var usuario = await jwtService.RetornarUsuarioJwt();

        var saldo = await movimentacaoRepository.RetornarSaldo(usuario);
        var totalDespesas = await movimentacaoRepository.SumValoresByTipo(Enums.Tipo.Despesa, usuario);
        var totalReceitas = await movimentacaoRepository.SumValoresByTipo(Enums.Tipo.Receita, usuario);

        return new ResumoResponse(totalReceitas, totalDespesas, saldo);
    }

    public async Task<List<TotalPorCategoriaResponse>> TotalPorCategoria()
    {
        return await movimentacaoRepository.TotalPorCategoria(await jwtService.RetornarUsuarioJwt());
    }

}