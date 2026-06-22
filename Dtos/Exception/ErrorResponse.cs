namespace ControleFinanceiro.Dtos.Exception;

public record ErrorResponse(
    int Status,
    string Mensagem
);