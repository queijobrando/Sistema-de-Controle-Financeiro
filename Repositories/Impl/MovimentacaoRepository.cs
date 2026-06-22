using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Repositories.Impl;

public class MovimentacaoRepository(ApplicationDbContext context) : IMovimentacaoRepository
{
    public async Task<List<Movimentacao>> ListAsync()
    {
        return await context.Movimentacoes
            .Include(m => m.Categoria)
            .ToListAsync();
    }

    public async Task<Movimentacao?> FindByIdAsync(int id)
    {
        return await context.Movimentacoes
            .Include(m => m.Categoria)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task AddAsync(Movimentacao movimentacao)
    {
        await context.Movimentacoes.AddAsync(movimentacao);
    }

    public void DeleteAsync(Movimentacao movimentacao)
    {
        context.Movimentacoes.Remove(movimentacao);
    }
}