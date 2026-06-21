using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Repositories.Impl;

public class CategoriaRepository(ApplicationDbContext context) : ICategoriaRepository
{
    public async Task<List<Categoria>> ListAsync()
    {
        return await context.Categorias.ToListAsync();
    }

    public async Task<Categoria?> FindByIdAsync(int id)
    {
        return await context.Categorias.FindAsync(id);
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

    public async Task<bool> ExistsByNome(string nome)
    {
        if (await context.Categorias.AnyAsync(c=> c.Nome == nome))
        {
            return true;
        }

        return false;
    }
}