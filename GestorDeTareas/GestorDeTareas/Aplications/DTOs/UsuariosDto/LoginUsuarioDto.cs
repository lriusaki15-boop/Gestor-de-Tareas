using System.ComponentModel.DataAnnotations;
using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Aplications.DTOs.UsuariosDto
{
    public class LoginUsuarioDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Contrasenia { get; set; }

        public LoginUsuarioDto() { }

        public LoginUsuarioDto(string email,string contrasenia)
        {
            this.Email = email;
            this.Contrasenia = contrasenia;
        }
    }
}
