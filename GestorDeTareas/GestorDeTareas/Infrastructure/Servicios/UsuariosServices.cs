using GestorDeTareas.Aplications.DTOs.UsuariosDto;
using GestorDeTareas.Dominio.Entities;
using GestorDeTareas.Dominio.Enums;
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

        public List<UsuariosDto>? ObtenerListaUsuarios() => _repositorio.ObtenerTodos();

        public UsuariosDto? ObtenerDatosUsuario(long id) => _repositorio.ObtenerUsuarioPorId(id);

        public Usuarios? ObtenerPorEmail(string email) => _repositorio.ObtenerPorEmail(email);

        public List<UsuariosDto> ObtenerPorDatosUsuario(string? nombre, string? apellidos, string? email, TipoUsuario? tipoUsuario) => _repositorio.ObtenerPorDatosUsuario(nombre, apellidos, email, tipoUsuario);

        public void EliminarUsuario(long id) => _repositorio.EliminarUsuario(id);

        public void ActualizarUsuario(UsuariosDto usuario) => _repositorio.ActualizarDatosUsuario(usuario);
    }
}
