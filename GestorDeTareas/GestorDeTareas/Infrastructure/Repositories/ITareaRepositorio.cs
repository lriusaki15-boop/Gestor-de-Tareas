using GestorDeTareas.Aplications.DTOs;
using GestorDeTareas.Dominio.Entities;

namespace GestorDeTareas.Infrastructure.Repositories
{
    public interface ITareaRepositorio
    {
        List<Tarea>ObtenerTodas();
        Tarea? ObtenerPorId(int id);
        void Agregar(TareaDto tarea);
        void Actualizar(Tarea tarea);
        void Eliminar(Tarea tarea);
    }
}
