using ControleFinanceiro.Dtos.Exception;
using Microsoft.AspNetCore.Diagnostics;

namespace ControleFinanceiro.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var (status, mensagem) = exception switch
        {
            ArgumentException ex => (StatusCodes.Status400BadRequest, ex.Message),
            KeyNotFoundException ex => (StatusCodes.Status404NotFound, ex.Message),
            UnauthorizedAccessException ex => (StatusCodes.Status401Unauthorized, ex.Message),
            _ => (StatusCodes.Status500InternalServerError, "Erro interno do servidor")
        };

        context.Response.StatusCode = status;
        context.Response.ContentType = "application/json";

        var response = new ErrorResponse(status, mensagem);
        await context.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}