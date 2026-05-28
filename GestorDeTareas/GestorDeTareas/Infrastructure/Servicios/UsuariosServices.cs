using GestorDeTareas.Aplications.DTOs.UsuariosDto;
using GestorDeTareas.Dominio.Entities;
using GestorDeTareas.Infrastructure.Repositories;
namespace GestorDeTareas.Infrastructure.Servicios
{
    public class UsuariosServices
    {
        private readonly IUsuariosRepositorio _repositorio;

        public UsuariosServices(IUsuariosRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<UsuariosDto>? ObtenerListaUsuarios() => _repositorio.ObtenerTodos();

        public UsuariosDto? ObtenerDatosUsuario(long id) => _repositorio.ObtenerUsuarioPorId(id);

        public Usuarios? ObtenerPorEmail(string email) => _repositorio.ObtenerPorEmail(email);

        public void EliminarUsuario(long id) => _repositorio.EliminarUsuario(id);

        public void ActualizarUsuario(UsuariosDto usuario) => _repositorio.ActualizarDatosUsuario(usuario);
    }
}
