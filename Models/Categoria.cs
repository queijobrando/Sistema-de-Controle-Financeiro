using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Models;

public class Categoria
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o nome")]
    [StringLength(80, ErrorMessage = "O nome deve conter até 80 caracteres")]
    [MinLength(5, ErrorMessage = "O nome deve conter pelo menos 5 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public Usuario Usuario { get; set; } = null!;
}