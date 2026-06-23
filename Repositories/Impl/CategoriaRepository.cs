using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Repositories.Impl;

public class CategoriaRepository(ApplicationDbContext context) : ICategoriaRepository
{
    public async Task<List<Categoria>> ListAsync(Usuario usuario)
    {
        return await context.Categorias.Where(c => c.Usuario == usuario).ToListAsync();
    }

    public async Task<Categoria?> FindByIdAsync(int id, Usuario usuario)
    {
        return await context.Categorias.FirstOrDefaultAsync(c => c.Id == id && c.Usuario == usuario);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task AddAsync(Categoria categoria)
    {
        await context.Categorias.AddAsync(categoria);
    }

    public void DeleteAsync(Categoria categoria)
    {
        context.Categorias.Remove(categoria);
    }

    public async Task<bool> ExistsByNome(string nome, Usuario usuario)
    {
        if (await context.Categorias.AnyAsync(c => c.Nome == nome && c.Usuario == usuario))
        {
            return true;
        }

        return false;
    }
}