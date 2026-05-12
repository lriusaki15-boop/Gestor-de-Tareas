using GestorDeTareas.Infrastructure.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeTareas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController :ControllerBase
    {
        private readonly UsuariosServices _servicio;
    }
}
