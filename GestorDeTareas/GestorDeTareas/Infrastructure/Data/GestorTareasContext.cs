using GestorDeTareas.Aplications.DTOs;
using GestorDeTareas.Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorDeTareas.Infrastructure.Data;
public class GestorTareasContext : DbContext
{
    public GestorTareasContext(DbContextOptions<GestorTareasContext> options) : base(options){ }

    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<TareaAction> Tarea { get; set; }

}