using GestorDeTareas.Aplications.DTOs.TareasDto;
using GestorDeTareas.Dominio.Entities;

namespace GestorDeTareas.Infrastructure.Repositories
{
    public interface ITareaRepositorio
    {
        List<Tarea>ObtenerTodas();
        Tarea? ObtenerPorId(long id);
        void Agregar(CrearTareaDto tarea);
        void Actualizar(Tarea tarea);
        void Eliminar(long id);
    }
}
