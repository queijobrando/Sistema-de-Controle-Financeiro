using ControleFinanceiro.Models;

namespace ControleFinanceiro.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario?> FindByEmail(string email);
    Task<Usuario?> FindById(int id);
    Task<bool> ExistsByEmail(string email);
    Task SaveChangesAsync();
    Task AddAsync(Usuario usuario);
}