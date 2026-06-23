using ControleFinanceiro.Dtos.Auth;
using ControleFinanceiro.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AuthService authService) : ControllerBase
{
    [HttpPost("registrar")]
    public async Task<ActionResult<AuthResponse>> Registrar([FromBody] RegisterRequest dto)
    {
        var response = await authService.Registrar(dto);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest dto)
    {
        var response = await authService.Login(dto);
        return Ok(response);
    }
}