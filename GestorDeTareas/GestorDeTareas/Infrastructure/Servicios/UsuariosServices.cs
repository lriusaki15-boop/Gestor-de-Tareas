using GestorDeTareas.Aplications.DTOs;
using GestorDeTareas.Infrastructure.Repositories;
namespace GestorDeTareas.Infrastructure.Servicios
{
    public class UsuariosServices
    {
        private readonly IUsuariosRepositorio _repositorio;

        public List<UsuariosDto> ObtenerListaUsuarios() => _repositorio.ObtenerTodos();

        public UsuariosDto ObtenerDatosUsuario(int id) => _repositorio.ObtenerUsuarioPorId(id);

        public UsuariosDto CrearUsuario(UsuariosDto usuario)
        {
            _repositorio.CrearUsuario(usuario);
            return usuario;
        }

        public void EliminarUsuario(int id) => _repositorio.EliminarUsuario(id);

        public void ActualizarUsuario(UsuariosDto usuario) => _repositorio.ActualizarDatosUsuario(usuario);
    }
}
