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
            throw new NotImplementedException();
        }

        public void Agregar(TareaDto tarea)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Tarea tarea)
        {
            throw new NotImplementedException();
        }

        public Tarea? ObtenerPorId(int id) => _context.Tarea.FirstOrDefault(t => t.Id == id);

        public List<Tarea> ObtenerTodas() => _context.Tarea.ToList();
    }
}
