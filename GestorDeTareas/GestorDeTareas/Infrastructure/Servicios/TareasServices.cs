using GestorDeTareas.Dominio.Entities;
using GestorDeTareas.Infrastructure.Repositories;
using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Infrastructure.Servicios
{
    public class TareasServices
    {
        private readonly ITareaRepositorio _repositorio;

        public TareasServices(ITareaRepositorio repositorio)
        => _repositorio = repositorio;

        public List<Tarea> ObtenerTodas() => _repositorio.ObtenerTodas();
        public Tarea? ObtenerPorId(int id) => _repositorio.ObtenerPorId(id);

        //public Tarea Crear(Tarea tareaDatos)
        //{
        //    // Validación de negocio — no pertenece al controller
        //    if (string.IsNullOrWhiteSpace())
        //        throw new ArgumentException("El título no puede estar vacío");

        //    //var tarea = new TareaAction
        //    //{ };
        //    //_repositorio.Agregar(tarea);
        //    return tarea;
        //}

        //Rehacer la estructura de la logica para que estas tareas funcionen
        public void Completar(int id)
        {
            var tarea = _repositorio.ObtenerPorId(id)
            ?? throw new KeyNotFoundException($"No existe la tarea con Id {id}");
            //tarea.Estado = EstadoTarea.Completada;
            _repositorio.Actualizar(tarea);
        }
    }
}
