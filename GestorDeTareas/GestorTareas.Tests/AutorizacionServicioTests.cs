using GestorDeTareas.Infrastructure.Servicios;
using GestorDeTareas.Infrastructure.Repositories;
using GestorDeTareas.Aplications.DTOs.UsuariosDto;
using Microsoft.Extensions.Configuration;
using static GestorDeTareas.Dominio.Enums.Enumerados;
using GestorDeTareas.Dominio.Entities;

namespace GestorTareas.Tests;

public class AutorizacionServicioTests
{
    private AutorizacionServicio _service;
    private FakeUsuariosRepo _repo;

    [SetUp]
    public void Setup()
    {
        _repo = new FakeUsuariosRepo();

        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Jwt:ClaveSecreta"] = "12345678901234567890123456789012",
                ["Jwt:Emisor"] = "test",
                ["Jwt:Audiencia"] = "test",
                ["Jwt:ExpiracionMinutos"] = "60"
            })
            .Build();

        _service = new AutorizacionServicio(_repo, config);
    }

    [Test]
    public void Login_UsuarioCorrecto_DebeDevolverToken()
    {
        var user = new Usuarios
        {
            Id = 1,
            Email = "test@test.com",
            Nombre = "Test",
            Contrasenia = BCrypt.Net.BCrypt.HashPassword("1234"),
            Rango = TipoUsuario.Admin
        };

        _repo.Seed(user);

        var result = _service.Login(new LoginUsuarioDto("test@test.com", "1234"));

        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Clave, Is.Not.Empty);
    }

    [Test]
    public void Login_PasswordIncorrecta_DebeDevolverNull()
    {
        var user = new Usuarios
        {
            Id = 1,
            Email = "test@test.com",
            Contrasenia = BCrypt.Net.BCrypt.HashPassword("1234"),
            Rango = TipoUsuario.Admin
        };

        _repo.Seed(user);

        var result = _service.Login(new LoginUsuarioDto("test@test.com", "wrong"));

        Assert.That(result, Is.Null);
    }

    private class FakeUsuariosRepo : IUsuariosRepositorio
    {
        private readonly List<Usuarios> _data = new();

        public void Seed(Usuarios u) => _data.Add(u);

        public Usuarios? ObtenerPorEmail(string email)
            => _data.FirstOrDefault(x => x.Email == email);

        public void CrearUsuario(CrearUsuarioDto usuario)
        {
            _data.Add(new Usuarios
            {
                Id = _data.Count + 1,
                Email = usuario.Email,
                Nombre = usuario.Nombre,
                Contrasenia = usuario.Contrasenia,
                Rango = usuario.Rango
            });
        }

        public List<UsuariosDto>? ObtenerTodos() => null;
        public UsuariosDto? ObtenerUsuarioPorId(long id) => null;
        public List<UsuariosDto>? ObtenerPorDatosUsuario(string? n, string? a, string? e, TipoUsuario? t) => null;
        public void ActualizarDatosUsuario(UsuariosDto usuario) { }
        public void EliminarUsuario(long id) { }
    }
}