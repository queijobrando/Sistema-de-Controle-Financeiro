using ControleFinanceiro.Dtos.Categoria;
using ControleFinanceiro.Models;
using ControleFinanceiro.Repositories;

namespace ControleFinanceiro.Services;

public class CategoriaService(
    ICategoriaRepository categoriaRepository,
    JwtService jwtService
    )
{
    public async Task<CategoriaResponse> CriarCategoria(CategoriaRequest dto)
    {
        var usuario = await jwtService.RetornarUsuarioJwt();

        var jaExiste = await categoriaRepository.ExistsByNome(dto.Nome, usuario);

        if (jaExiste)
        {
            throw new ArgumentException("Já existe uma categoria com esse nome");
        }

        var categoria = new Categoria
        {
            Nome = dto.Nome,
            Usuario = usuario
        };

        await categoriaRepository.AddAsync(categoria);
        await categoriaRepository.SaveChangesAsync();

        return new CategoriaResponse(categoria.Id, categoria.Nome);
    }

    public async Task<CategoriaResponse?> BuscarPorId(int id)
    {
        var categoria = await categoriaRepository.FindByIdAsync(id, await jwtService.RetornarUsuarioJwt());

        if (categoria != null)
        {
            return new CategoriaResponse(categoria.Id, categoria.Nome);
        }

        return null;
    }

    public async Task<Categoria?> RetornarPorId(int id)
    {
        return await categoriaRepository.FindByIdAsync(id, await jwtService.RetornarUsuarioJwt());
    }

    public async Task<List<CategoriaResponse>> ListarCategorias()
    {
        var lista = await categoriaRepository.ListAsync(await jwtService.RetornarUsuarioJwt());

        return lista.ConvertAll(c => new CategoriaResponse(c.Id, c.Nome));
    }

    public async Task<CategoriaResponse?> EditarCategoria(int id, CategoriaEdit dto)
    {
        var categoria = await categoriaRepository.FindByIdAsync(id, await jwtService.RetornarUsuarioJwt());

        if (categoria != null)
        {

            categoria.Nome = dto.Nome;
            await categoriaRepository.SaveChangesAsync();
            return new CategoriaResponse(categoria.Id, categoria.Nome);
        }

        return null;
    }

    public async Task<bool> DeletarPorId(int id)
    {
        var categoria = await categoriaRepository.FindByIdAsync(id, await jwtService.RetornarUsuarioJwt());

        if (categoria != null)
        {
            categoriaRepository.DeleteAsync(categoria);
            await categoriaRepository.SaveChangesAsync();
            return true;
        }

        return false;
    }
}