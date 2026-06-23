using ControleFinanceiro.Dtos.Auth;
using ControleFinanceiro.Models;
using ControleFinanceiro.Repositories;

namespace ControleFinanceiro.Services;

public class AuthService(IUsuarioRepository usuarioRepository, JwtService jwtService)
{
    public async Task<AuthResponse> Registrar(RegisterRequest dto)
    {
        var jaExiste = await usuarioRepository.ExistsByEmail(dto.Email);

        if (jaExiste)
        {
            throw new ArgumentException("Email já cadastrado");
        }

        var usuario = new Usuario
        {
            Email = dto.Email,
            Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha)
        };

        await usuarioRepository.AddAsync(usuario);
        await usuarioRepository.SaveChangesAsync();

        return new AuthResponse(jwtService.GerarToken(usuario));
    }

    public async Task<AuthResponse> Login(LoginRequest dto)
    {
        var usuario = await usuarioRepository.FindByEmail(dto.Email);

        if (usuario == null || !BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.Senha))
        {
            throw new UnauthorizedAccessException("Email ou senha inválidos");
        }

        return new AuthResponse(jwtService.GerarToken(usuario));
    }
}