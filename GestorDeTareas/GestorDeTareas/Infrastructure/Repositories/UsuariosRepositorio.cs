
using GestorDeTareas.Aplications.DTOs.UsuariosDto;
using GestorDeTareas.Dominio.Entities;
using GestorDeTareas.Dominio.Enums;
using GestorDeTareas.Infrastructure.Data;
using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Infrastructure.Repositories
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private readonly GestorTareasContext _context;

        public UsuariosRepositorio(GestorTareasContext context) => _context = context;

        public void ActualizarDatosUsuario(UsuariosDto datosUsuario)
        {
            var usuario = new Usuarios
            {
                Nombre = datosUsuario.Nombre,
                Apellidos = datosUsuario.Apellidos,
                Email = datosUsuario.Email,
                Rango = datosUsuario.Rango
            };
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void CrearUsuario(CrearUsuarioDto usuarioNuevoDatos)
        {
            var nuevoUsuario = new Usuarios
            {
                Nombre = usuarioNuevoDatos.Nombre,
                Apellidos = usuarioNuevoDatos.Apellidos,
                Email = usuarioNuevoDatos.Email,
                Contrasenia = usuarioNuevoDatos.Contrasenia,
                Rango = usuarioNuevoDatos.Rango
            };
            _context.Usuarios.Add(nuevoUsuario);
            _context.SaveChanges();
        }

        public void EliminarUsuario(long id)
        {
            var usuario = ObtenerUsuarioPorId(id);
            if (usuario is null) return;

            var usuarioEliminar = new Usuarios
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellidos = usuario.Apellidos,
                Email = usuario.Email,
                Rango = usuario.Rango
            };
            _context.Usuarios.Remove(usuarioEliminar);
            _context.SaveChanges();
        }

        public UsuariosDto? ObtenerUsuarioPorId(long id) => _context.Usuarios.Select(t => new UsuariosDto { Id = t.Id, Nombre = t.Nombre, Apellidos = t.Apellidos, Email = t.Email, Rango = t.Rango }).FirstOrDefault(t => t.Id == id);

        public List<UsuariosDto> ObtenerTodos() => _context.Usuarios.Select(t => new UsuariosDto {Id = t.Id, Nombre = t.Nombre, Apellidos = t.Apellidos, Email = t.Email, Rango = t.Rango}).ToList();

        public Usuarios ObtenerPorLogin(string email, string contrasenia) => _context.Usuarios.FirstOrDefault(d => d.Email == email && d.Contrasenia == contrasenia);

        public Usuarios ObtenerPorEmail(string email) => _context.Usuarios.FirstOrDefault(d => d.Email == email);

        public List<UsuariosDto>? ObtenerPorDatosUsuario(string? nombre, string? apellidos, string? email, TipoUsuario? tipoUsuario) => _context.Usuarios.Where(t => t.Nombre == nombre && t.Apellidos == apellidos && t.Email == email && t.Rango == tipoUsuario).Select(t => new UsuariosDto {Id = t.Id, Nombre = t.Nombre, Apellidos = t.Apellidos, Email = t.Email, Rango = t.Rango}).ToList();
    }
}
