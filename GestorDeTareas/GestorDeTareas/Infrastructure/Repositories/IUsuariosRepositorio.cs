using GestorDeTareas.Aplications.DTOs;

namespace GestorDeTareas.Infrastructure.Repositories
{
    public interface IUsuariosRepositorio
    {
        List<UsuariosDto> ObtenerTodos();
        UsuariosDto? ObtenerUsuarioPorId(int id);
        void CrearUsuario(UsuariosDto usuario);
        void ActualizarDatosUsuario(UsuariosDto usuario);
        void EliminarUsuario(int id);
    }
}
