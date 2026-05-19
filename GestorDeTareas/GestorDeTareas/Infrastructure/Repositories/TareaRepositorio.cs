using GestorDeTareas.Aplications.DTOs;
using GestorDeTareas.Dominio.Entities;
using GestorDeTareas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestorDeTareas.Infrastructure.Repositories
{
    public class TareaRepositorio : ITareaRepositorio
    {
        private readonly GestorTareasContext _context;

        public TareaRepositorio(GestorTareasContext context) => _context = context;

        public void Actualizar(TareaDto tarea)
        {
            _context.Tarea.Update(tarea);
            _context.SaveChanges();
        }

        public void Agregar(CrearTareaDto tarea)
        {
            var tareaDto = new TareaDto
            {
                Titulo = tarea.Titulo,
                Descripcion = tarea.Descripcion,
                Responsable = tarea.Responsable,
                FechaCreacion = tarea.FechaCreacion, 
                Estado = tarea.Estado, 
                Prioridad = tarea.Prioridad, 
                UsuarioId = tarea.UsuarioId
            };
            _context.Tarea.Add(tareaDto);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var tarea = ObtenerPorId(id);
            _context.Tarea.Remove(tarea);
            _context.SaveChanges();
        }

        public TareaDto? ObtenerPorId(int id) => _context.Tarea.FirstOrDefault(t => t.Id == id);

        public List<TareaDto> ObtenerTodas() => _context.Tarea.Select(t => new TareaDto(t.Id, t.Titulo, t.Descripcion, t.Responsable,
            t.FechaCreacion, t.FechaFinTarea, t.Prioridad, t.Estado, t.MotivoCancelacion, t.UsuarioId)).ToList();
    }
}
