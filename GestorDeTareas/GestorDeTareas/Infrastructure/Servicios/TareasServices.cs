using GestorDeTareas.Aplications.DTOs.TareasDto;
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

        public List<Tarea> ObtenerTodas() => _repositorio.ObtenerTodas();
        public Tarea? ObtenerPorId(long id) => _repositorio.ObtenerPorId(id);

        public CrearTareaDto Crear(CrearTareaDto tareaDatos)
        {
            _repositorio.Agregar(tareaDatos);
            return tareaDatos;
        }

        public void EliminarTarea(long id)=> _repositorio.Eliminar(id);
        public void ActualizarEstadosTarea(long id, string? motivoCancelacion, EstadoTarea estado)
        {
            var tarea = _repositorio.ObtenerPorId(id) ?? throw new KeyNotFoundException($"No existe la tarea con Id {id}");
            if (estado == EstadoTarea.Completada)
            {
                tarea.Estado = estado;
                tarea.FechaFinTarea = DateTime.Now;
                _repositorio.Actualizar(tarea);
            }
            else if (estado == EstadoTarea.Cancelada)
            {
                tarea.Estado = estado;
                tarea.MotivoCancelacion = motivoCancelacion;
                _repositorio.Actualizar(tarea);
            }
            else if(estado == EstadoTarea.EnProgreso || estado == EstadoTarea.Pendiente)
            {
                tarea.Estado = estado;
                _repositorio.Actualizar(tarea);
            }
        }

        public void ActualizarPrioridadTarea(long id, PrioridadTarea prioridad)
        {
            var tarea = _repositorio.ObtenerPorId(id) ?? throw new KeyNotFoundException($"No existe la tarea con Id {id}");
            
            tarea.Prioridad = prioridad;
            _repositorio.Actualizar(tarea);
        }

        public void ActualizarTarea(TareaDto tareaDto)
        {
            var tarea = _repositorio.ObtenerPorId(tareaDto.Id) ?? throw new KeyNotFoundException($"No existe la tarea con Id {tareaDto.Id}");

            tarea.Titulo = tareaDto.Titulo;
            tarea.Descripcion = tareaDto.Descripcion;
            tarea.Estado = tareaDto.Estado;
            tarea.Prioridad = tareaDto.Prioridad;
            if(tareaDto.Estado == EstadoTarea.Cancelada)
            {
                tarea.MotivoCancelacion = tareaDto.MotivoCancelacion;
                tarea.FechaFinTarea = DateTime.Now;
            }
            _repositorio.Actualizar(tarea);
        }
    }
}
