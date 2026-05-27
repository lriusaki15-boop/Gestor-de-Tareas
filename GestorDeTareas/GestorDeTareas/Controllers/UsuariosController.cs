using GestorDeTareas.Aplications.DTOs.UsuariosDto;
using GestorDeTareas.Infrastructure.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuariosController :ControllerBase
    {
        private readonly UsuariosServices _servicio;

        public UsuariosController(UsuariosServices servicio) => _servicio = servicio;

        /// <summary>
        /// Obtiene los datos de un Usuario.
        /// </summary>
        /// <returns>Devuelve la informacion de 1 Usuario.</returns>
        [HttpGet("ObtenerUsuarioPorID/{id}")]
        public IActionResult ObtenerUsuarioPorId(long id)
        {
            var usuario = _servicio.ObtenerDatosUsuario(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        /// <summary>
        /// Obtiene un listado con la informacion basica de los Usuarios.
        /// </summary>
        /// <returns>Devuelve la informacion de todos los Usuarios.</returns>
        [HttpGet("ObtenerListadoUsuarios/")]
        public IActionResult ObtenerListadoUsuarios()
        {
            var usuario = _servicio.ObtenerListaUsuarios();

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        /// <summary>
        /// Obtiene el Usuario por su correo electronico.
        /// </summary>
        /// <returns>Devuelve la informacion de un Usuario por su Email.</returns>
        [HttpGet("ObtenerUsuarioPorEmail/{email}")]
        public IActionResult ObtenerUsuarioPorEmail(string email)
        {
            var usuario = _servicio.ObtenerPorEmail(email);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        /// <summary>
        /// Elimina a un Usuario.
        /// </summary>
        /// <returns>Elimina a un Usuario.</returns>
        [HttpDelete("EliminarUsuario/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult EliminarUsuario(long id)
        {
            _servicio.EliminarUsuario(id);
            return NoContent();
        }

        /// <summary>
        /// Actualiza los datos de un Usuario.
        /// </summary>
        /// <returns>Actualiza los datos de un Usuario.</returns>
        [HttpPut("ActualizarDatosUsuario/{id}")]
        public IActionResult ActualizarDatosUsuario(long id)
        {
            var usuario = _servicio.ObtenerDatosUsuario(id);
            _servicio.ActualizarUsuario(usuario);
            return NoContent();
        }
    }
}
