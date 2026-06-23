using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ControleFinanceiro.Models;
using ControleFinanceiro.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace ControleFinanceiro.Services;

public class JwtService(
    IUsuarioRepository usuarioRepository,
    IConfiguration configuration,
    IHttpContextAccessor httpContextAccessor
)
{
    public string GerarToken(Usuario usuario)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)
        );

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email)
        };

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8), // expira
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<Usuario> RetornarUsuarioJwt()
    {
        var idClaim = httpContextAccessor.HttpContext?.User
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (idClaim == null)
        {
            throw new UnauthorizedAccessException("Usuário não autenticado");
        }

        var usuario = await usuarioRepository.FindById(int.Parse(idClaim));

        if (usuario == null)
        {
            throw new UnauthorizedAccessException("Usuário não encontrado");
        }

        return usuario;
    }
}