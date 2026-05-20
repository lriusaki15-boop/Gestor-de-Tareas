
using GestorDeTareas.Dominio.Entities;
using GestorDeTareas.Infrastructure.Repositories;
namespace GestorDeTareas.Infrastructure.Servicios
{
    public class UsuariosServices
    {
        private readonly IUsuariosRepositorio _repositorio;

        public List<Usuarios> ObtenerListaUsuarios() => _repositorio.ObtenerTodos();

        public Usuarios ObtenerDatosUsuario(int id) => _repositorio.ObtenerUsuarioPorId(id);

        public Usuarios CrearUsuario(Usuarios usuario)
        {
            _repositorio.CrearUsuario(usuario);
            return usuario;
        }

        public void EliminarUsuario(int id) => _repositorio.EliminarUsuario(id);

        public void ActualizarUsuario(Usuarios usuario) => _repositorio.ActualizarDatosUsuario(usuario);
    }
}
