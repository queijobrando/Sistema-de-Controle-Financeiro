namespace ControleFinanceiro.Dtos.Relatorio;

public record TotalPorCategoriaResponse(
    string Categoria,
    decimal Total
);