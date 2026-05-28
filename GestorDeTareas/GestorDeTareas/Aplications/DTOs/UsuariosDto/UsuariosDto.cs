using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Aplications.DTOs.UsuariosDto
{
    public class UsuariosDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public TipoUsuario Rango { get; set; }

        public UsuariosDto(){}

        public UsuariosDto(long id, string nombre, string apellidos, TipoUsuario rango)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Rango = rango;
        }
    }
}
