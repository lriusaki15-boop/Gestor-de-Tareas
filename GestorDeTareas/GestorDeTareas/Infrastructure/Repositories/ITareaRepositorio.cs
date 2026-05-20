using GestorDeTareas.Aplications.DTOs;
using GestorDeTareas.Dominio.Entities;

namespace GestorDeTareas.Infrastructure.Repositories
{
    public interface ITareaRepositorio
    {
        List<TareaAction>ObtenerTodas();
        TareaAction? ObtenerPorId(int id);
        void Agregar(CrearTareaDto tarea);
        void Actualizar(TareaAction tarea);
        void Eliminar(int id);
    }
}
