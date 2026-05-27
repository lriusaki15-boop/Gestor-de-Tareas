using GestorDeTareas.Aplications.DTOs.UsuariosDto;
using GestorDeTareas.Infrastructure.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeTareas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorizacionController : ControllerBase
    {
        private readonly AutorizacionServicio _autorizacionService;

        public AutorizacionController(AutorizacionServicio authService)
        => _autorizacionService = authService;

        // POST /api/auth/registro
        [HttpPost("registro")]
        [AllowAnonymous]
        public IActionResult Registrar([FromBody] CrearUsuarioDto crearUsuarioDatos)
        {
            var resultado = _autorizacionService.Registrar(crearUsuarioDatos);
            if (resultado == null)
                return Conflict("El email ya está registrado");
            return Ok(resultado);
        }

        // POST /api/auth/login
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginUsuarioDto dto)
        {
            var resultado = _autorizacionService.Login(dto);
            if (resultado == null)
                return Unauthorized("Credenciales incorrectas");
            return Ok(resultado);
        }
    }
}
