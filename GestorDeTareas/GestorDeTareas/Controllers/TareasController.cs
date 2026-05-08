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

        [HttpGet("{id}")]
        public IActionResult ObtenerTareaPorId(int id)
        {
            var tarea = _servicio.ObtenerPorId(id);

            if (tarea == null)
                return NotFound();

            return Ok(tarea);
        }

        [HttpGet]
        public IActionResult ObtenerTodasTareas()
        {
            var tareas = _servicio.ObtenerTodas();

            if (tareas == null)
                return NotFound();

            return Ok(tareas);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarTarea(int id)
        {
            _servicio.EliminarTarea(id);
            return NoContent();
        }

        [HttpPut("{id}", Name= "Completar Tarea")]
        public IActionResult CompletarTarea(int id)
        {
            _servicio.CompletarTarea(id);
            return NoContent();
        }
    }
}
