using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Aplications.DTOs
{
    public class UsuariosDto
    {
        public int Id { get; set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Email { get; private set; }
        public string ContraseniaHash { get; set; }
        public TipoUsuario Rango { get; set; }

        public UsuariosDto(){}

        public UsuariosDto(int id, string nombre, string apellido, string contrasenia, TipoUsuario rango)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.ContraseniaHash = contrasenia;
            this.Rango = rango;
        }
    }
}
