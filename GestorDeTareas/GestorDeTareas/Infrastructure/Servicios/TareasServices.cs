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

        //Rehacer la estructura de la logica para que estas tareas funcionen
        public void CompletarTarea(int id)
        {
            var tarea = _repositorio.ObtenerPorId(id) ?? throw new KeyNotFoundException($"No existe la tarea con Id {id}");
            tarea.Estado = EstadoTarea.Completada;
            _repositorio.Actualizar(tarea);
        }
        public void EliminarTarea(int id)=> _repositorio.Eliminar(id);

    }
}
