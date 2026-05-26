using GestorDeTareas.Aplications.DTOs.ClaveDto;
using GestorDeTareas.Aplications.DTOs.UsuariosDto;
using GestorDeTareas.Dominio.Entities;
using GestorDeTareas.Infrastructure.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Infrastructure.Servicios
{
    public class AutorizacionServicio
    {
        private readonly IUsuariosRepositorio _repositorio;
        private readonly IConfiguration _config;

        public AutorizacionServicio(IUsuariosRepositorio repositorio, IConfiguration config)
        {
            _repositorio = repositorio;
            _config = config;
        }

        public ClaveResponseDto? Login(LoginUsuarioDto dto)
        {
            var usuario = _repositorio.ObtenerPorEmail(dto.Email);
            if (usuario == null) return null;

            if (!BCrypt.Net.BCrypt.Verify(dto.Contrasenia, usuario.Contrasenia))
                return null;

            return GenerarClave(usuario);
        }

        private ClaveResponseDto GenerarClave(Usuarios usuario)
        {
            var expiracion = DateTime.UtcNow.AddMinutes(
            int.Parse(_config["Jwt:ExpiracionMinutos"]!));
            string esAdmin;

            if (usuario.Rango == TipoUsuario.Admin)
                esAdmin = "Admin";
            else
                esAdmin = "User";

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, esAdmin)
            };

            var clave = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:ClaveSecreta"]!));
            var credenciales = new SigningCredentials(clave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: _config["Jwt:Emisor"],
            audience: _config["Jwt:Audiencia"],
            claims: claims,
            expires: expiracion,
            signingCredentials: credenciales);

            return new ClaveResponseDto
            {
                Clave = new JwtSecurityTokenHandler().WriteToken(token),
                Expira = expiracion
            };
        }
    }
}
