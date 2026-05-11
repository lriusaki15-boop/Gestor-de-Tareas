using GestorDeTareas.Dominio.Entities;
using GestorDeTareas.Infrastructure.Data;
using GestorDeTareas.Infrastructure.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorDeTareas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        /// Actualiza el estado de una tarea a Completa.
        /// </summary>
        /// <returns>No devuleve nada a no ser que haya habido un fallo.</returns>
        [HttpPut("ActualizarCompletarTarea/{id}")]
        public IActionResult CompletarTarea(int id)
        {
            _servicio.CompletarTarea(id);
            return NoContent();
        }

        /// <summary>
        /// Actualiza el estado de una tarea a Pendiente.
        /// </summary>
        /// <returns>No devuleve nada a no ser que haya habido un fallo.</returns>
        [HttpPut("ActualizarPendienteTarea/{id}")]
        public IActionResult PendienteTarea(int id)
        {
            _servicio.PendienteTarea(id);
            return NoContent();
        }

        /// <summary>
        /// Actualiza el estado de una tarea a EnProgreso.
        /// </summary>
        /// <returns>No devuleve nada a no ser que haya habido un fallo.</returns>
        [HttpPut("ActualizarEnProgresoTarea/{id}")]
        public IActionResult EnProgresoTarea(int id)
        {
            _servicio.EnProgresoTarea(id);
            return NoContent();
        }

        /// <summary>
        /// Actualiza el estado de una tarea a Cancelada y se le da un motivo de cancelacion.
        /// </summary>
        /// <returns>No devuleve nada a no ser que haya habido un fallo.</returns>
        [HttpPut("ActualizarCancelarTarea/{id}")]
        public IActionResult CancelarTarea(int id, string motivoCancelacion)
        {
            _servicio.CancelarTarea(id, motivoCancelacion);
            return NoContent();
        }

        /// <summary>
        /// Actualiza la Prioridad de una tarea a Baja.
        /// </summary>
        /// <returns>No devuleve nada a no ser que haya habido un fallo.</returns>
        [HttpPut("ActualizarPrioridadBajaTarea/{id}")]
        public IActionResult PrioridadBajaTarea(int id)
        {
            _servicio.PrioridadBajaTarea(id);
            return NoContent();
        }

        /// <summary>
        /// Actualiza la Prioridad de una tarea a Media.
        /// </summary>
        /// <returns>No devuleve nada a no ser que haya habido un fallo.</returns>
        [HttpPut("ActualizarPrioridadMediaTarea/{id}")]
        public IActionResult PrioridadMediaTarea(int id)
        {
            _servicio.PrioridadMediaTarea(id);
            return NoContent();
        }

        /// <summary>
        /// Actualiza la Prioridad de una tarea a Alta.
        /// </summary>
        /// <returns>No devuleve nada a no ser que haya habido un fallo.</returns>
        [HttpPut("ActualizarPrioridadAltaTarea/{id}")]
        public IActionResult PrioridadAltaTarea(int id)
        {
            _servicio.PrioridadMediaTarea(id);
            return NoContent();
        }
    }
}
