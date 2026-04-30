using GestorDeTareas.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeTareas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly GestorTareasContext _context;

        public TareasController(GestorTareasContext context)
        {
            _context = context;
        }
    }
}
