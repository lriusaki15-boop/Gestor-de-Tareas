using GestorDeTareas.Dominio.Entities;
using GestorDeTareas.Infrastructure.Servicios;
using GestorDeTareas.Infrastructure.Repositories;
using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorTareas.Tests;

public class TareasServicesTests
{
    private TareasServices _service;
    private FakeTareaRepositorio _repo;

    [SetUp]
    public void Setup()
    {
        _repo = new FakeTareaRepositorio();
        _service = new TareasServices(_repo);
    }

    [Test]
    public void Crear_Tarea_DebeAgregarlaAlRepositorio()
    {
        var dto = new GestorDeTareas.Aplications.DTOs.TareasDto.CrearTareaDto(
            "Test",
            "Desc",
            "Juan",
            PrioridadTarea.Media,
            EstadoTarea.Pendiente,
            1
        );

        _service.Crear(dto);

        Assert.That(_repo.Tareas.Count, Is.EqualTo(1));
        Assert.That(_repo.Tareas[0].Titulo, Is.EqualTo("Test"));
    }

    [Test]
    public void Eliminar_Tarea_DebeEliminarla()
    {
        _repo.Seed(new Tarea { Id = 1, Titulo = "T1" });

        _service.EliminarTarea(1);

        Assert.That(_repo.Tareas.Count, Is.EqualTo(0));
    }

    [Test]
    public void ActualizarEstado_ACompletada_DebeSetearFechaFin()
    {
        _repo.Seed(new Tarea
        {
            Id = 1,
            Estado = EstadoTarea.EnProgreso
        });

        _service.ActualizarEstadosTarea(1, null, EstadoTarea.Completada);

        var tarea = _repo.Tareas.First();

        Assert.That(tarea.Estado, Is.EqualTo(EstadoTarea.Completada));
        Assert.That(tarea.FechaFinTarea, Is.Not.Null);
    }

    private class FakeTareaRepositorio : ITareaRepositorio
    {
        public List<Tarea> Tareas { get; } = new();

        public void Seed(Tarea t) => Tareas.Add(t);

        public void Agregar(GestorDeTareas.Aplications.DTOs.TareasDto.CrearTareaDto tarea)
        {
            Tareas.Add(new Tarea
            {
                Id = Tareas.Count + 1,
                Titulo = tarea.Titulo,
                Descripcion = tarea.Descripcion,
                Responsable = tarea.Responsable,
                Estado = tarea.Estado,
                Prioridad = tarea.Prioridad,
                UsuarioId = tarea.UsuarioId
            });
        }

        public void Actualizar(Tarea tarea)
        {
            var idx = Tareas.FindIndex(x => x.Id == tarea.Id);
            if (idx >= 0) Tareas[idx] = tarea;
        }

        public void Eliminar(long id)
        {
            Tareas.RemoveAll(x => x.Id == id);
        }

        public Tarea? ObtenerPorId(long id) => Tareas.FirstOrDefault(x => x.Id == id);

        public List<Tarea> ObtenerTodas() => Tareas;
    }
}
