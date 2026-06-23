using ControleFinanceiro.Dtos.Relatorio;
using ControleFinanceiro.Enums;
using ControleFinanceiro.Models;

namespace ControleFinanceiro.Repositories;

public interface IMovimentacaoRepository
{
    Task<List<Movimentacao>> ListAsync(Usuario usuario);
    Task<decimal> RetornarSaldo(Usuario usuario);
    Task<decimal> SumValoresByTipo(Tipo tipo, Usuario usuario);
    Task<List<TotalPorCategoriaResponse>> TotalPorCategoria(Usuario usuario);
    Task<Movimentacao?> FindByIdAsync(int id, Usuario usuario);
    Task SaveChangesAsync();
    Task AddAsync(Movimentacao movimentacao);
    void DeleteAsync(Movimentacao movimentacao);
}