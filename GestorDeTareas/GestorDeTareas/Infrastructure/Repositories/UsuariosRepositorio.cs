
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

        public void CrearUsuario(Usuarios usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void EliminarUsuario(int id)
        {
            var usuario = ObtenerUsuarioPorId(id);
            _context.Usuarios.Remove(usuario);
        }

        public Usuarios? ObtenerUsuarioPorId(int id) => _context.Usuarios.FirstOrDefault(t => t.Id == id);


        public List<Usuarios> ObtenerTodos() => _context.Usuarios.ToList();
    }
}
