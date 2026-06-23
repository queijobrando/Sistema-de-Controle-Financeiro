using ControleFinanceiro.Models;

namespace ControleFinanceiro.Repositories;

public interface ICategoriaRepository
{
    Task<List<Categoria>> ListAsync(Usuario usuario);
    Task<Categoria?> FindByIdAsync(int id, Usuario usuario);
    Task SaveChangesAsync();
    Task AddAsync(Categoria categoria);
    void DeleteAsync(Categoria categoria);
    Task<bool> ExistsByNome(string nome, Usuario usuario);
}