using GestorDeTareas.Aplications.DTOs.UsuariosDto;
using GestorDeTareas.Infrastructure.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeTareas.Controllers
{
    public class AutorizacionController : ControllerBase
    {
        private readonly AutorizacionServicio _autorizacionService;

        public AutorizacionController(AutorizacionServicio authService)
        => _autorizacionService = authService;

        // POST /api/auth/login
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginUsuarioDto dto)
        {
            var resultado = _autorizacionService;
            if (resultado == null)
                return Unauthorized("Credenciales incorrectas");
            return Ok(resultado);
        }
    }
}
