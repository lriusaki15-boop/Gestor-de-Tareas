using GestorDeTareas.Dominio.Entities;
using GestorDeTareas.Infrastructure.Data;
using GestorDeTareas.Infrastructure.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TareasController : ControllerBase
    {
        private readonly TareasServices _servicio;
        public TareasController(TareasServices servicio) => _servicio = servicio;

        /// <summary>
        /// Obtiene una tarea en especifica.
        /// </summary>
        /// <returns>Devuelve la informacion de 1 tarea al completo.</returns>
        [HttpGet("ObtenerTareasPorID/{id}")]
        public IActionResult ObtenerTareaPorId(int id)
        {
            var tarea = _servicio.ObtenerPorId(id);

            if (tarea == null)
                return NotFound();

            return Ok(tarea);
        }

        /// <summary>
        /// Obtiene todas las tareas del sistema.
        /// </summary>
        /// <returns>Lista de tareas con el nombre de su usuario asignado.</returns>
        [HttpGet("ObtenerTodasTareas")]
        public IActionResult ObtenerTodasTareas()
        {
            var tareas = _servicio.ObtenerTodas();

            if (tareas == null)
                return NotFound();

            return Ok(tareas);
        }

        /// <summary>
        /// Elimina una tarea en especifico.
        /// </summary>
        /// <returns>No devuleve nada a no ser de que haya fallado.</returns>
        [HttpDelete("EliminarTarea/{id}")]
        public IActionResult EliminarTarea(int id)
        {
            _servicio.EliminarTarea(id);
            return NoContent();
        }

        /// <summary>
        /// Actualiza el estado de una tarea.
        /// </summary>
        /// <returns>No devuleve nada a no ser que haya habido un fallo.</returns>
        [HttpPut("ActualizarEstadoTarea/{id}, {estado}")]
        public IActionResult CompletarTarea(int id, EstadoTarea estado, string? motivoCancelacion)
        {
            if(estado == EstadoTarea.Completada)
                _servicio.CompletarTarea(id);
            if (estado == EstadoTarea.Pendiente)
                _servicio.PendienteTarea(id);
            if (estado == EstadoTarea.EnProgreso)
                _servicio.EnProgresoTarea(id);
            if (estado == EstadoTarea.Cancelada)
                _servicio.CancelarTarea(id, motivoCancelacion);
            return NoContent();
        }

        
        /// <summary>
        /// Actualiza la Prioridad de una tarea.
        /// </summary>
        /// <returns>No devuleve nada a no ser que haya habido un fallo.</returns>
        [HttpPut("ActualizarPrioridadTarea/{id}, {prioridad}")]
        public IActionResult ActualizaPrioridadTarea(int id, PrioridadTarea prioridad)
        {
            if(prioridad == PrioridadTarea.Baja)
                _servicio.PrioridadBajaTarea(id);
            if (prioridad == PrioridadTarea.Media)
                _servicio.PrioridadMediaTarea(id);
            if (prioridad == PrioridadTarea.Alta)
                _servicio.PrioridadAltaTarea(id);
            return NoContent();
        }
    }
}
