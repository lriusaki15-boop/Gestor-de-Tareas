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

        public void Agregar(TareaDto tarea)
        {
            _context.Tarea.Add(tarea);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var tarea = ObtenerPorId(id);
            _context.Tarea.Remove(tarea);
            _context.SaveChanges();
        }

        public TareaDto? ObtenerPorId(int id) => _context.Tarea.FirstOrDefault(t => t.Id == id);

        public List<TareaDto> ObtenerTodas() => _context.Tarea.ToList();
    }
}
