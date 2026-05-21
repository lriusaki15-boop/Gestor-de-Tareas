
using GestorDeTareas.Aplications.DTOs.UsuariosDto;
using GestorDeTareas.Dominio.Entities;
using GestorDeTareas.Infrastructure.Repositories;
using static GestorDeTareas.Dominio.Enums.Enumerados;
namespace GestorDeTareas.Infrastructure.Servicios
{
    public class UsuariosServices
    {
        private readonly IUsuariosRepositorio _repositorio;

        public UsuariosServices(IUsuariosRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Usuarios> ObtenerListaUsuarios() => _repositorio.ObtenerTodos();

        public Usuarios ObtenerDatosUsuario(int id) => _repositorio.ObtenerUsuarioPorId(id);

        public Usuarios CrearUsuario(string nombre, string apellido, string email, TipoUsuario tipo)
        {
            var nuevoUsuario = new CrearUsuarioDto { nombre, apellido, email, tipo };
            _repositorio.CrearUsuario(nuevoUsuario);
            return usuario;
        }

        public void EliminarUsuario(int id) => _repositorio.EliminarUsuario(id);

        public void ActualizarUsuario(Usuarios usuario) => _repositorio.ActualizarDatosUsuario(usuario);
    }
}
