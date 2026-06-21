using ControleFinanceiro.Models;

namespace ControleFinanceiro.Repositories;

public interface ICategoriaRepository
{
    Task<List<Categoria>> ListAsync();
    Task<Categoria?> FindByIdAsync(int id);
    Task SaveChangesAsync();
    Task AddAsync(Categoria categoria);
    void DeleteAsync(Categoria categoria);
    Task<bool> ExistsByNome(string nome);
}