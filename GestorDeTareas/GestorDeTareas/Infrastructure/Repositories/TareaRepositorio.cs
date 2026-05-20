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

        public void Actualizar(Tarea tarea)
        {
            _context.Tarea.Update(tarea);
            _context.SaveChanges();
        }

        public void Agregar(CrearTareaDto tarea)
        {
            var tareaDto = new Tarea
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

            if (tarea is null)
                return;

            _context.Tarea.Remove(tarea);
            _context.SaveChanges();
        }

        public Tarea? ObtenerPorId(int id) => _context.Tarea.FirstOrDefault(t => t.Id == id);

        public List<Tarea> ObtenerTodas() => _context.Tarea.ToList();
    }
}
