using ControleFinanceiro.Enums;
using ControleFinanceiro.Models;

namespace ControleFinanceiro.Repositories;

public interface IMovimentacaoRepository
{
    Task<List<Movimentacao>> ListAsync();
    Task<decimal> RetornarSaldo();
    Task<decimal> SumValoresByTipo(Tipo tipo);
    Task<Movimentacao?> FindByIdAsync(int id);
    Task SaveChangesAsync();
    Task AddAsync(Movimentacao movimentacao);
    void DeleteAsync(Movimentacao movimentacao);
}