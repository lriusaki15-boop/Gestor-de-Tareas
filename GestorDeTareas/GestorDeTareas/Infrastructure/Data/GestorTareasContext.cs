using GestorDeTareas.Domine.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorDeTareas.Infrastructure.Data;
public class GestorTareasContext : DbContext
{
    // Cada DbSet representa una tabla en la BD
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Tarea> Tarea { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Indicar a EF Core qué proveedor usar y cómo conectarse
        options.UseSqlServer(
        @"Server=localhost\SQLEXPRESS;" +
        "Database=GestorTareas;" +
        "Trusted_Connection=True;" +
        "TrustServerCertificate=True;"
        );
    }
}