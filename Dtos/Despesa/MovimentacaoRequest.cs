using System.ComponentModel.DataAnnotations;
using ControleFinanceiro.Enums;

namespace ControleFinanceiro.Dtos.Despesa;

public record MovimentacaoRequest(
    [Required(ErrorMessage = "Informe o valor")]
    decimal Valor,

    [Required(ErrorMessage = "Informe o tipo")]
    [EnumDataType(typeof(Tipo), ErrorMessage = "Tipo inválido")]
    Tipo Tipo,

    [Required(ErrorMessage = "Informe a categoria")]
    int CategoriaId,

    [Required(ErrorMessage = "Informe a data")]
    DateOnly Data
);