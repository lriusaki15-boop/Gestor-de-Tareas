using GestorDeTareas.Aplications.DTOs;
using GestorDeTareas.Dominio.Entities;

namespace GestorDeTareas.Infrastructure.Repositories
{
    public interface IUsuariosRepositorio
    {
        List<Usuarios> ObtenerTodos();
        Usuarios? ObtenerUsuarioPorId(int id);
        void CrearUsuario(Usuarios usuario);
        void ActualizarDatosUsuario(Usuarios usuario);
        void EliminarUsuario(int id);
    }
}
