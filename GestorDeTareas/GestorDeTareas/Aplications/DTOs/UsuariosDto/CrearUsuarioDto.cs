using System.ComponentModel.DataAnnotations;
using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Aplications.DTOs.UsuariosDto
{
    public class CrearUsuarioDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorio")]
        public string Apellidos { get; set; }

        [Required, EmailAddress(ErrorMessage = "Formato de email no válido")]
        public string Email { get; set; }

        [Required, MinLength(8, ErrorMessage = "Mínimo 8 caracteres")]
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
