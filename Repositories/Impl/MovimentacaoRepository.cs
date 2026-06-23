using ControleFinanceiro.Data;
using ControleFinanceiro.Dtos.Relatorio;
using ControleFinanceiro.Enums;
using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Repositories.Impl;

public class MovimentacaoRepository(ApplicationDbContext context) : IMovimentacaoRepository
{
    public async Task<List<Movimentacao>> ListAsync(Usuario usuario)
    {
        return await context.Movimentacoes
            .Where(m=> m.Usuario == usuario)
            .Include(m => m.Categoria)
            .ToListAsync();
    }

    public async Task<Movimentacao?> FindByIdAsync(int id, Usuario usuario)
    {
        return await context.Movimentacoes
            .Include(m => m.Categoria)
            .FirstOrDefaultAsync(m => m.Id == id && m.Usuario == usuario);
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

    public async Task<decimal> RetornarSaldo(Usuario usuario)
    {
        return await context.Movimentacoes
            .GroupBy(_ => 1)
            .Select(g =>
                g.Where(m => m.Tipo == Tipo.Receita && m.Usuario == usuario).Sum(m => m.Valor) -
                g.Where(m => m.Tipo == Tipo.Despesa && m.Usuario == usuario).Sum(m => m.Valor)
            )
            .FirstOrDefaultAsync();
    }

    public async Task<decimal> SumValoresByTipo(Tipo tipo, Usuario usuario)
    {
        return await context.Movimentacoes
            .Where(m => m.Tipo == tipo && m.Usuario == usuario)
            .SumAsync(m => m.Valor);
    }

    public async Task<List<TotalPorCategoriaResponse>> TotalPorCategoria(Usuario usuario)
    {
        return await context.Movimentacoes
            .Where(m=> m.Usuario == usuario)
            .Include(m => m.Categoria)
            .GroupBy(m => m.Categoria.Nome)
            .Select(g => new TotalPorCategoriaResponse(
                g.Key,
                g.Sum(m => m.Valor)
            ))
            .ToListAsync();
    }
}