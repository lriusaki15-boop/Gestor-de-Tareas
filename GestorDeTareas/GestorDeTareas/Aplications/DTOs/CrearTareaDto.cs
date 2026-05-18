using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Aplications.DTOs
{
    public class CrearTareaDto
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Responsable { get; set; }
        public DateTime FechaCreacion { get; set; }
        public PrioridadTarea Prioridad { get; set; }
        public EstadoTarea Estado { get; set; }
        public int UsuarioId { get; set; }

        public CrearTareaDto(string titulo, string descripcion, string responsable, DateTime fechaCreacion, PrioridadTarea prioridad, EstadoTarea estado, int usuarioId)
        {
            this.Titulo = titulo;
            this.Descripcion = descripcion;
            this.FechaCreacion = fechaCreacion;
            this.Prioridad = prioridad;
            this.Estado = estado;
            this.UsuarioId = usuarioId;
        }
    }
}
