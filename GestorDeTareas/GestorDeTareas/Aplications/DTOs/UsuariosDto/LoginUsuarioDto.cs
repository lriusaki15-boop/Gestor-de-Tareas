using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Aplications.DTOs.UsuariosDto
{
    public class LoginUsuarioDto
    {
        public string Email { get; private set; }
        public string ContraseniaHash { get; set; }
        public TipoUsuario Rango { get; set; }

        public LoginUsuarioDto() { }

        public LoginUsuarioDto(string email,string contrasenia, TipoUsuario rango)
        {
            this.Email = email;
            this.ContraseniaHash = contrasenia;
            this.Rango = rango;
        }
    }
}
