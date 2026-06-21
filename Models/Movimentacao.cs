using System.ComponentModel.DataAnnotations;
using ControleFinanceiro.Enums;

namespace ControleFinanceiro.Models;

public class Movimentacao
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o valor")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "Informe o tipo")]
    public Tipo Tipo { get; set; }

    [Required(ErrorMessage = "Informe a categoria")]
    public Categoria Categoria { get; set; } = null!;

    [Required(ErrorMessage = "Informe a data")]
    public DateOnly Data { get; set; }
}