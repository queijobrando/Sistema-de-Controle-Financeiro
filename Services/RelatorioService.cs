using ControleFinanceiro.Dtos.Relatorio;
using ControleFinanceiro.Repositories;

namespace ControleFinanceiro.Services;

public class RelatorioService(IMovimentacaoRepository movimentacaoRepository)
{

    public async Task<SaldoResponse> RetornarSaldo()
    {
        var saldo = await movimentacaoRepository.RetornarSaldo();

        return new SaldoResponse(saldo);
    }

    public async Task<ResumoResponse> RetornarResumo()
    {
        var saldo = await movimentacaoRepository.RetornarSaldo();
        var totalDespesas = await movimentacaoRepository.SumValoresByTipo(Enums.Tipo.Despesa);
        var totalReceitas = await movimentacaoRepository.SumValoresByTipo(Enums.Tipo.Receita);

        return new ResumoResponse(totalReceitas, totalDespesas, saldo);
    }

    public async Task<List<TotalPorCategoriaResponse>> TotalPorCategoria()
    {
        return await movimentacaoRepository.TotalPorCategoria();
    }

}