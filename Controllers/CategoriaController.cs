using ControleFinanceiro.Dtos.Categoria;
using ControleFinanceiro.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController(CategoriaService categoriaService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CategoriaResponse>> CriarCategoria([FromBody] CategoriaRequest dto)
    {
        var categoria = await categoriaService.CriarCategoria(dto);

        return CreatedAtAction(
            nameof(BuscarPorId),
            new { id = categoria.Id },
            categoria
        );
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoriaResponse>> BuscarPorId([FromRoute] int id)
    {
        var categoria = await categoriaService.BuscarPorId(id);

        if (categoria == null)
        {
            return NotFound();
        }

        return Ok(categoria);
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoriaResponse>>> ListarCategorias()
    {
        var lista = await categoriaService.ListarCategorias();

        if (lista.Count == 0)
        {
            return NoContent();
        }

        return Ok(lista);
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<CategoriaResponse>> EditarCategoria([FromRoute] int id, [FromBody] CategoriaEdit dto)
    {
        var categoria = await categoriaService.EditarCategoria(id, dto);

        if (categoria != null)
        {
            return Ok(categoria);
        }

        return NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeletarPorId([FromRoute] int id)
    {
        var resposta = await categoriaService.DeletarPorId(id);

        if (resposta)
        {
            return NoContent();
        }

        return NotFound();
    }
}