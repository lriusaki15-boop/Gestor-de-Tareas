using GestorDeTareas.Aplications.DTOs;
using GestorDeTareas.Dominio.Entities;

namespace GestorDeTareas.Infrastructure.Repositories
{
    public interface ITareaRepositorio
    {
        List<TareaDto>ObtenerTodas();
        TareaDto? ObtenerPorId(int id);
        void Agregar(CrearTareaDto tarea);
        void Actualizar(TareaDto tarea);
        void Eliminar(int id);
    }
}
