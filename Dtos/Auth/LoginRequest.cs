using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Dtos.Auth;

public record LoginRequest(
    [Required(ErrorMessage = "Informe um email válido")]
    string Email,
    string Senha
);