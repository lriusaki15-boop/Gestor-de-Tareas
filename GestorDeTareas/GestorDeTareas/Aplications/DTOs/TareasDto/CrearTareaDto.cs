using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Aplications.DTOs.TareasDto
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

        public CrearTareaDto()
        {

        }
        public CrearTareaDto(string titulo, string descripcion, string responsable, DateTime fechaCreacion, PrioridadTarea prioridad, EstadoTarea estado, int usuarioId)
        {
            this.Titulo = titulo;
            this.Descripcion = descripcion;
            this.Responsable = responsable;
            this.FechaCreacion = fechaCreacion;
            this.Prioridad = prioridad;
            this.Estado = estado;
            this.UsuarioId = usuarioId;
        }

        public CrearTareaDto(string titulo, string responsable, DateTime fechaCreacion, PrioridadTarea prioridad, EstadoTarea estado, int usuarioId)
        {
            Titulo = titulo;
            Responsable = responsable;
            FechaCreacion = fechaCreacion;
            Prioridad = prioridad;
            Estado = estado;
            UsuarioId = usuarioId;
        }
    }
}
