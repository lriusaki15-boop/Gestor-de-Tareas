
using GestorDeTareas.Aplications.DTOs.UsuariosDto;
using GestorDeTareas.Dominio.Entities;
using GestorDeTareas.Dominio.Enums;
using GestorDeTareas.Infrastructure.Data;

namespace GestorDeTareas.Infrastructure.Repositories
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private readonly GestorTareasContext _context;

        public UsuariosRepositorio(GestorTareasContext context) => _context = context;

        public void ActualizarDatosUsuario(Usuarios usuario)
        {
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

        public UsuariosDto ObtenerPorEmail(string email) => _context.Usuarios.Select(t => new UsuariosDto { Id = t.Id, Nombre = t.Nombre, Apellidos = t.Apellidos, Email = t.Email, Rango = t.Rango }).FirstOrDefault(d => d.Email == email);
    }
}
