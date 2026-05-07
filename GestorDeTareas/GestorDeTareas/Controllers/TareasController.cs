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
        //// Pañar estos metodos añadir lo siguiente: CreatedAtAction(
        //[HttpDelete("{id}")]
        //public IActionResult EliminarTarea(int id)
        //{
        //    var tarea = _servicio.EliminarTarea;
        //    return Ok(tarea);
        //}

        //[HttpPut("{id}")]
        //public IActionResult CompletarTarea(int id)
        //{

        //    return Ok(_servicio.CompletarTarea(id));
        //}
    }
}
