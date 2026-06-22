using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Dtos.Categoria;

public record CategoriaRequest(
    [Required(ErrorMessage = "Informe o nome da categoria")]
    string Nome
);