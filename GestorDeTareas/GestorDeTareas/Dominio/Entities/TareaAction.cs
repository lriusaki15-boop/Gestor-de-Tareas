using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Dominio.Entities
{
    public class TareaAction : Tarea
    {
        private readonly List<Tarea>? _subTareas = new();

        [JsonConstructor]
        public TareaAction(int Id, string Titulo, string Descripcion, string Responsable, DateTime FechaCreacion, DateTime? FechaFinTarea, PrioridadTarea Prioridad, string? MotivacionCancelacion, List<Tarea> _subTareas, EstadoTarea Estado, int TotalSubtareas, int SubtareasCompletadas, int UsuarioId)
            : base(Id, Titulo, Descripcion, Responsable, FechaCreacion, FechaFinTarea, Prioridad, MotivacionCancelacion, Estado, UsuarioId)
        {
        }

        public TareaAction(int id, string titulo, string descripcion, string responsable, DateTime fechaCreacion, DateTime? fechaFinTarea, PrioridadTarea prioridad, EstadoTarea estado, string? motivoCancelacion, int usuarioId)
        {
            Id = id;
            Titulo = titulo;
            Descripcion = descripcion;
            Responsable = responsable;
            FechaCreacion = fechaCreacion;
            FechaFinTarea = fechaFinTarea;
            Prioridad = prioridad;
            Estado = estado;
            MotivoCancelacion = motivoCancelacion;
            UsuarioId = usuarioId;
        }

        public void AgregarSubtarea(Tarea subtarea) => _subTareas.Add(subtarea);

        public int TotalSubtareas => _subTareas.Count;
        public int SubtareasCompletadas => _subTareas.Count(subTareas => subTareas.Estado == EstadoTarea.Completada);

        public override string ObtenerResumen()
        {
            return "Resmune de tarea con los datos:\n" + this.Id + "\nTitulo:" + this.Titulo
                + "\nDescripcion:" + this.Descripcion + "\nEstado de la tarea:" + this.Estado;
        }
    }
}
