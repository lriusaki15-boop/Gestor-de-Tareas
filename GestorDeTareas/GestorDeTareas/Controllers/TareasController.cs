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

    }
}
