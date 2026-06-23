using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Repositories.Impl;

public class UsuarioRepository(ApplicationDbContext context) : IUsuarioRepository
{
    public async Task<Usuario?> FindByEmail(string email)
    {
        return await context.Usuarios.FirstOrDefaultAsync(u=> u.Email == email);
    }

    public async Task<Usuario?> FindById(int id)
    {
        return await context.Usuarios.FindAsync(id);
    }

    public async Task<bool> ExistsByEmail(string email)
    {
        if (await context.Usuarios.AnyAsync(u=> u.Email == email))
        {
            return true;
        }

        return false;
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task AddAsync(Usuario usuario)
    {
        await context.Usuarios.AddAsync(usuario);
    }
}