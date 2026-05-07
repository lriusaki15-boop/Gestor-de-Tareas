using GestorDeTareas.Aplications.DTOs;
using GestorDeTareas.Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorDeTareas.Infrastructure.Data;
public class GestorTareasContext : DbContext
{
    // Cada DbSet representa una tabla en la BD
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<TareaDto> Tarea { get; set; }

}