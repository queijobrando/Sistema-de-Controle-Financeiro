using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Dtos.Auth;

public record RegisterRequest(
    [Required(ErrorMessage = "Informe um email válido")]
    string Email,
    [Required(ErrorMessage = "Informe uma senha")]
    string Senha
);