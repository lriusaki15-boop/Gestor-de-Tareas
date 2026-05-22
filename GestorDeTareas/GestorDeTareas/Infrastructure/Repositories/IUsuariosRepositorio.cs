using GestorDeTareas.Aplications.DTOs;
using GestorDeTareas.Aplications.DTOs.UsuariosDto;
using GestorDeTareas.Dominio.Entities;

namespace GestorDeTareas.Infrastructure.Repositories
{
    public interface IUsuariosRepositorio
    {
        List<Usuarios> ObtenerTodos();
        Usuarios? ObtenerUsuarioPorId(long id);
        void CrearUsuario(CrearUsuarioDto usuario);
        void ActualizarDatosUsuario(Usuarios usuario);
        void EliminarUsuario(long id);
    }
}
