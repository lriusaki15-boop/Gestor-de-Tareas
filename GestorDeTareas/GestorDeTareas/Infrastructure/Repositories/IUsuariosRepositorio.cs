using GestorDeTareas.Aplications.DTOs;
using GestorDeTareas.Aplications.DTOs.UsuariosDto;
using GestorDeTareas.Dominio.Entities;
using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Infrastructure.Repositories
{
    public interface IUsuariosRepositorio
    {
        List<UsuariosDto>? ObtenerTodos();
        UsuariosDto? ObtenerUsuarioPorId(long id);
        Usuarios? ObtenerPorEmail(string email);
        List<UsuariosDto>? ObtenerPorDatosUsuario(string? nombre, string? apellidos, string? email, TipoUsuario? tipoUsuario);
        void CrearUsuario(CrearUsuarioDto usuario);
        void ActualizarDatosUsuario(UsuariosDto usuario);
        void EliminarUsuario(long id);
    }
}
