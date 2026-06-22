namespace ControleFinanceiro.Dtos.Relatorio;

public record ResumoResponse(
    decimal TotalReceitas,
    decimal TotalDespesas,
    decimal Saldo
);