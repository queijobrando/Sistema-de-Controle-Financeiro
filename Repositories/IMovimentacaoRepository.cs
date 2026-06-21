using ControleFinanceiro.Models;

namespace ControleFinanceiro.Repositories;

public interface IMovimentacaoRepository
{
    Task<List<Movimentacao>> ListAsync();
    Task<Movimentacao?> FindByIdAsync(int id);
    Task SaveChangesAsync();
    Task AddAsync(Movimentacao movimentacao);
    void DeleteAsync(Movimentacao movimentacao);
}