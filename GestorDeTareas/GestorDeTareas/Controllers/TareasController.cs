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

        [HttpGet("Obtener-Tareas-Por-ID/{id}")]
        public IActionResult ObtenerTareaPorId(int id)
        {
            var tarea = _servicio.ObtenerPorId(id);

            if (tarea == null)
                return NotFound();

            return Ok(tarea);
        }

        [HttpGet("Obtener-Todas-Tareas")]
        public IActionResult ObtenerTodasTareas()
        {
            var tareas = _servicio.ObtenerTodas();

            if (tareas == null)
                return NotFound();

            return Ok(tareas);
        }

        [HttpDelete("Eliminar-Tarea/{id}")]
        public IActionResult EliminarTarea(int id)
        {
            _servicio.EliminarTarea(id);
            return NoContent();
        }

        [HttpPut("Actualizar-Completar-Tarea/{id}")]
        public IActionResult CompletarTarea(int id)
        {
            _servicio.CompletarTarea(id);
            return NoContent();
        }

        [HttpPut("Actualizar-Pendiente-Tarea/{id}")]
        public IActionResult PendienteTarea(int id)
        {
            _servicio.PendienteTarea(id);
            return NoContent();
        }

        [HttpPut("Actualizar-En-Progreso-Tarea/{id}")]
        public IActionResult EnProgresoTarea(int id)
        {
            _servicio.EnProgresoTarea(id);
            return NoContent();
        }

        [HttpPut("Actualizar-Cancelar-Tarea/{id}")]
        public IActionResult CancelarTarea(int id, string motivoCancelacion)
        {
            _servicio.CancelarTarea(id, motivoCancelacion);
            return NoContent();
        }

        [HttpPut("Actualizar-Prioridad-Baja-Tarea/{id}")]
        public IActionResult PrioridadBajaTarea(int id)
        {
            _servicio.PrioridadBajaTarea(id);
            return NoContent();
        }

        [HttpPut("Actualizar-Prioridad-Media-Tarea/{id}")]
        public IActionResult PrioridadMediaTarea(int id)
        {
            _servicio.PrioridadMediaTarea(id);
            return NoContent();
        }

        [HttpPut("Actualizar-Prioridad-Alta-Tarea/{id}")]
        public IActionResult PrioridadAltaTarea(int id)
        {
            _servicio.PrioridadMediaTarea(id);
            return NoContent();
        }
    }
}
