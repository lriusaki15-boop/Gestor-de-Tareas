using GestorDeTareas.Aplications.DTOs.UsuariosDto;
using GestorDeTareas.Infrastructure.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController :ControllerBase
    {
        private readonly UsuariosServices _servicio;

        public UsuariosController(UsuariosServices servicio) => _servicio = servicio;

        /// <summary>
        /// Obtiene los datos de un Usuario.
        /// </summary>
        /// <returns>Devuelve la informacion de 1 Usuario.</returns>
        [HttpGet("ObtenerUsuarioPorID/{id}")]
        public IActionResult ObtenerUsuarioPorId(int id)
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
        /// Elimina a un Usuario.
        /// </summary>
        /// <returns>Elimina a un Usuario.</returns>
        [HttpDelete("EliminarUsuario/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult EliminarUsuario(int id)
        {
            _servicio.EliminarUsuario(id);
            return NoContent();
        }

        /// <summary>
        /// Actualiza los datos de un Usuario.
        /// </summary>
        /// <returns>Actualiza los datos de un Usuario.</returns>
        [HttpPut("ActualizarDatosUsuario/{id}")]
        public IActionResult ActualizarDatosUsuario(int id)
        {
            var usuario = _servicio.ObtenerDatosUsuario(id);
            _servicio.ActualizarUsuario(usuario);
            return NoContent();
        }

        /// <summary>
        /// Crea un Usuario nuevo.
        /// </summary>
        /// <returns>No devuelve nada ya que crea un usuario a no ser de que falle.</returns>
        [HttpPost("CrearUsuario")]
        public IActionResult CrearUsuario([FromBody] CrearUsuarioDto usuarioNuevo )
        {
            _servicio.CrearUsuario(usuarioNuevo);
            return NoContent();
        }
    }
}
