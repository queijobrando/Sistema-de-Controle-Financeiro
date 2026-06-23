using ControleFinanceiro.Dtos.Movimentacao;
using ControleFinanceiro.Models;
using ControleFinanceiro.Repositories;

namespace ControleFinanceiro.Services;

public class MovimentacaoService(
    IMovimentacaoRepository movimentacaoRepository,
    CategoriaService categoriaService,
    JwtService jwtService
)
{
    public async Task<MovimentacaoResponse> NovaMovimentacao(MovimentacaoRequest dto)
    {
        var categoria = await categoriaService.RetornarPorId(dto.CategoriaId);

        if (categoria == null)
        {
            throw new ArgumentException("Categoria inválida ou inexistente");
        }

        var usuario = await jwtService.RetornarUsuarioJwt();

        var movimentacao = new Movimentacao()
        {
            Valor = dto.Valor,
            Tipo = dto.Tipo,
            Categoria = categoria,
            Data = dto.Data,
            Usuario = usuario
        };

        await movimentacaoRepository.AddAsync(movimentacao);
        await movimentacaoRepository.SaveChangesAsync();

        return new MovimentacaoResponse(
            movimentacao.Id,
            movimentacao.Valor,
            movimentacao.Tipo,
            movimentacao.Categoria.Id,
            movimentacao.Data
        );
    }

    public async Task<List<MovimentacaoResponse>> ListarMovimentacoes()
    {
        var lista = await movimentacaoRepository.ListAsync(await jwtService.RetornarUsuarioJwt());

        return lista.ConvertAll(m => new MovimentacaoResponse(
            m.Id,
            m.Valor,
            m.Tipo,
            m.Categoria.Id,
            m.Data
        ));
    }

    public async Task<MovimentacaoResponse?> BuscarPorId(int id)
    {
        var movimentacao = await movimentacaoRepository.FindByIdAsync(id, await jwtService.RetornarUsuarioJwt());

        if (movimentacao != null)
        {
            return new MovimentacaoResponse(
                movimentacao.Id,
                movimentacao.Valor,
                movimentacao.Tipo,
                movimentacao.Categoria.Id,
                movimentacao.Data
            );
        }

        return null;
    }

    public async Task<bool> DeletarPorId(int id)
    {
        var movimentacao = await movimentacaoRepository.FindByIdAsync(id, await jwtService.RetornarUsuarioJwt());

        if (movimentacao != null)
        {
            movimentacaoRepository.DeleteAsync(movimentacao);
            await movimentacaoRepository.SaveChangesAsync();
            return true;
        }

        return false;
    }
}