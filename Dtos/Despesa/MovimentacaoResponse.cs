using ControleFinanceiro.Enums;

namespace ControleFinanceiro.Dtos.Despesa;

public record MovimentacaoResponse(
    int Id,
    decimal Valor,
    Tipo Tipo,
    int CategoriaId,
    DateOnly Data
);