using GestorDeTareas.Aplications.DTOs;
using GestorDeTareas.Dominio.Entities;
using GestorDeTareas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Infrastructure.Servicios
{
    public class TareasServices
    {
        private readonly ITareaRepositorio _repositorio;

        public TareasServices(ITareaRepositorio repositorio) => _repositorio = repositorio;

        public List<TareaDto> ObtenerTodas() => _repositorio.ObtenerTodas();
        public TareaDto? ObtenerPorId(int id) => _repositorio.ObtenerPorId(id);

        public TareaDto Crear(TareaDto tareaDatos)
        {
            _repositorio.Agregar(tareaDatos);
            return tareaDatos;
        }

        public void EliminarTarea(int id)=> _repositorio.Eliminar(id);
        public void CompletarTarea(int id)
        {
            var tarea = _repositorio.ObtenerPorId(id) ?? throw new KeyNotFoundException($"No existe la tarea con Id {id}");
            tarea.Estado = EstadoTarea.Completada;
            tarea.FechaFinTarea = DateTime.Now;
            _repositorio.Actualizar(tarea);
        }

        public void PendienteTarea(int id)
        {
            var tarea = _repositorio.ObtenerPorId(id) ?? throw new KeyNotFoundException($"No existe la tarea con Id {id}");
            tarea.Estado = EstadoTarea.Pendiente;
            _repositorio.Actualizar(tarea);
        }

        public void EnProgresoTarea(int id)
        {
            var tarea = _repositorio.ObtenerPorId(id) ?? throw new KeyNotFoundException($"No existe la tarea con Id {id}");
            tarea.Estado = EstadoTarea.EnProgreso;
            _repositorio.Actualizar(tarea);
        }

        public void CancelarTarea(int id, string motivoCancelacion)
        {
            var tarea = _repositorio.ObtenerPorId(id) ?? throw new KeyNotFoundException($"No existe la tarea con Id {id}");
            if (motivoCancelacion.Count() != 0)
                tarea.MotivoCancelacion = motivoCancelacion;
            tarea.Estado = EstadoTarea.Cancelada;
            _repositorio.Actualizar(tarea);
        }

        public void PrioridadBajaTarea(int id)
        {
            var tarea = _repositorio.ObtenerPorId(id) ?? throw new KeyNotFoundException($"No existe la tarea con Id {id}");
            tarea.Prioridad = PrioridadTarea.Baja;
            _repositorio.Actualizar(tarea);
        }

        public void PrioridadMediaTarea(int id)
        {
            var tarea = _repositorio.ObtenerPorId(id) ?? throw new KeyNotFoundException($"No existe la tarea con Id {id}");
            tarea.Prioridad = PrioridadTarea.Media;
            _repositorio.Actualizar(tarea);
        }

        public void PrioridadAltaTarea(int id)
        {
            var tarea = _repositorio.ObtenerPorId(id) ?? throw new KeyNotFoundException($"No existe la tarea con Id {id}");
            tarea.Prioridad = PrioridadTarea.Alta;
            _repositorio.Actualizar(tarea);
        }
    }
}
