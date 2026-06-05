using GestorDeTareas.Infrastructure.Servicios;
using GestorDeTareas.Infrastructure.Repositories;
using GestorDeTareas.Aplications.DTOs.UsuariosDto;
using static GestorDeTareas.Dominio.Enums.Enumerados;
using GestorDeTareas.Dominio.Entities;

namespace GestorTareas.Tests;

public class UsuariosServicesTests
{
    private UsuariosServices _service;
    private FakeUsuariosRepo _repo;

    [SetUp]
    public void Setup()
    {
        _repo = new FakeUsuariosRepo();
        _service = new UsuariosServices(_repo);
    }

    [Test]
    public void ObtenerUsuario_DebeDevolverUsuario()
    {
        _repo.Seed(new Usuarios { Id = 1, Nombre = "Ana" });

        var result = _service.ObtenerDatosUsuario(1);

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Nombre, Is.EqualTo("Ana"));
    }

    [Test]
    public void EliminarUsuario_DebeEliminar()
    {
        _repo.Seed(new Usuarios { Id = 1 });

        _service.EliminarUsuario(1);

        Assert.That(_repo.Data.Count, Is.EqualTo(0));
    }

    private class FakeUsuariosRepo : IUsuariosRepositorio
    {
        public List<Usuarios> Data { get; } = new();
        private List<UsuariosDto> Map() =>
            Data.Select(x => new UsuariosDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellidos = x.Apellidos,
                Email = x.Email,
                Rango = x.Rango
            }).ToList();

        public void Seed(Usuarios u) => Data.Add(u);

        public List<UsuariosDto>? ObtenerTodos() => Map();

        public UsuariosDto? ObtenerUsuarioPorId(long id)
            => Map().FirstOrDefault(x => x.Id == id);

        public Usuarios? ObtenerPorEmail(string email)
            => Data.FirstOrDefault(x => x.Email == email);

        public List<UsuariosDto>? ObtenerPorDatosUsuario(string? nombre, string? apellidos, string? email, TipoUsuario? tipoUsuario)
            => Map();

        public void CrearUsuario(CrearUsuarioDto usuario)
            => Data.Add(new Usuarios { Id = Data.Count + 1, Nombre = usuario.Nombre });

        public void ActualizarDatosUsuario(UsuariosDto usuario) { }

        public void EliminarUsuario(long id)
            => Data.RemoveAll(x => x.Id == id);
    }
}