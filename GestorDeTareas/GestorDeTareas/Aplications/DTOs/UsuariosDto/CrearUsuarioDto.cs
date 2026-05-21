using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Aplications.DTOs.UsuariosDto
{
    public class CrearUsuarioDto
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public TipoUsuario Rango { get; set; }

        public CrearUsuarioDto() { }

        public CrearUsuarioDto( string nombre, string apellidos, string contrasenia, TipoUsuario rango)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Contrasenia = contrasenia;
            this.Rango = rango;
        }
    }
}
