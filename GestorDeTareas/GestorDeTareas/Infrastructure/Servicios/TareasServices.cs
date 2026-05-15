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
        public void ActualizarEstadosTarea(int id, string? motivoCancelacion, EstadoTarea estado)
        {
            var tarea = _repositorio.ObtenerPorId(id) ?? throw new KeyNotFoundException($"No existe la tarea con Id {id}");
            if (estado == EstadoTarea.Completada)
            {
                tarea.Estado = estado;
                tarea.FechaFinTarea = DateTime.Now;
                _repositorio.Actualizar(tarea);
            }
            if (estado == EstadoTarea.Pendiente)
            {
                tarea.Estado = estado;
                _repositorio.Actualizar(tarea);
            }
            if (estado == EstadoTarea.EnProgreso)
            {
                tarea.Estado = estado;
                _repositorio.Actualizar(tarea);
            }
            if (estado == EstadoTarea.Cancelada)
            {
                tarea.Estado = estado;
                tarea.MotivoCancelacion = motivoCancelacion;
                _repositorio.Actualizar(tarea);
            }
        }

        public void ActualizarPrioridadTarea(int id, PrioridadTarea prioridad)
        {
            var tarea = _repositorio.ObtenerPorId(id) ?? throw new KeyNotFoundException($"No existe la tarea con Id {id}");
            if (prioridad == PrioridadTarea.Baja)
            {
                tarea.Prioridad = prioridad;
                _repositorio.Actualizar(tarea);
            }
            if (prioridad == PrioridadTarea.Media)
            {
                tarea.Prioridad = prioridad;
                _repositorio.Actualizar(tarea);
            }
            if (prioridad == PrioridadTarea.Alta)
            {
                tarea.Prioridad = prioridad;
                _repositorio.Actualizar(tarea);
            }

            _repositorio.Actualizar(tarea);
        }
    }
}
