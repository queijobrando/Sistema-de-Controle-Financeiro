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
}