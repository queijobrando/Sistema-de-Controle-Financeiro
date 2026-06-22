using ControleFinanceiro.Enums;

namespace ControleFinanceiro.Dtos.Movimentacao;

public record MovimentacaoResponse(
    int Id,
    decimal Valor,
    Tipo Tipo,
    int CategoriaId,
    DateOnly Data
);