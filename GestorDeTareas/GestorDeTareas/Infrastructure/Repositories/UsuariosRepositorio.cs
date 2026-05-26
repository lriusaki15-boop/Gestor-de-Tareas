
using GestorDeTareas.Aplications.DTOs.UsuariosDto;
using GestorDeTareas.Dominio.Entities;
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

        public void CrearUsuario(Usuarios usuarioNuevo)
        {
            _context.Usuarios.Add(usuarioNuevo);
            _context.SaveChanges();
        }

        public void EliminarUsuario(long id)
        {
            var usuario = ObtenerUsuarioPorId(id);
            if (usuario is null) return;

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public Usuarios? ObtenerUsuarioPorId(long id) => _context.Usuarios.FirstOrDefault(t => t.Id == id);


        public List<Usuarios> ObtenerTodos() => _context.Usuarios.ToList();

        public Usuarios? ObtenerPorEmail(string email) => _context.Usuarios.FirstOrDefault(t => t.Email == email);
    }
}
