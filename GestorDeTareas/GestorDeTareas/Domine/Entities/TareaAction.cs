using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using static GestorDeTareas.Domine.Enums.Enumerados;

namespace GestorDeTareas.Domine.Entities
{
    public class TareaAction : Tarea
    {
        private readonly List<Tarea>? _subTareas = new();

        [JsonConstructor]
        public TareaAction(int Id,string Titulo,string Descripcion,string Responsable,DateTime FechaCreacion,DateTime? FechaFinTarea,PrioridadTarea Prioridad,string? MotivacionCancelacion,List<Tarea> _subTareas, EstadoTarea Estado, int TotalSubtareas, int SubtareasCompletadas) 
            : base(Id,Titulo,Descripcion,Responsable,FechaCreacion,FechaFinTarea,Prioridad,MotivacionCancelacion, Estado)
        {
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
