
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

        public CrearUsuarioDto CrearUsuario(CrearUsuarioDto nuevoUsuario)
        {
            _repositorio.CrearUsuario(nuevoUsuario);
            return nuevoUsuario;
        }

        public void EliminarUsuario(int id) => _repositorio.EliminarUsuario(id);

        public void ActualizarUsuario(Usuarios usuario) => _repositorio.ActualizarDatosUsuario(usuario);
    }
}
