using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Aplications.DTOs.UsuariosDto
{
    public class CrearUsuarioDto
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Email { get; private set; }
        public string ContraseniaHash { get; set; }
        public TipoUsuario Rango { get; set; }

        public CrearUsuarioDto() { }

        public CrearUsuarioDto( string nombre, string apellido, string contrasenia, TipoUsuario rango)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.ContraseniaHash = contrasenia;
            this.Rango = rango;
        }
    }
}
