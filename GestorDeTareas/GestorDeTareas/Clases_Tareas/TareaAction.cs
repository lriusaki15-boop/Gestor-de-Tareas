using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GestorDeTareas.Clases_Tareas
{
    internal class TareaAction : Tarea
    {
        private readonly List<Tarea>? _subTareas = new();

        [JsonConstructor]
        public TareaAction(int id,string titulo,string descripcion,string responsable,DateTime fechaCreacion,DateTime? fechaFinTarea,PrioridadTarea prioridad,string? motivacionCancelacion,List<Tarea> _subTareas, EstadoTarea estado) : base(id,titulo,descripcion,responsable,fechaCreacion,fechaFinTarea,prioridad,motivacionCancelacion, estado)
        {
        }

        public void AgregarSubtarea(Tarea subtarea) => _subTareas.Add(subtarea);

        public int TotalSubtareas => _subTareas.Count;
        public int SubtareasCompletadas => _subTareas.Count(subTareas => subTareas.Estado == EstadoTarea.Completada);

        public override string ObtenerResumen()
        {
            throw new NotImplementedException();
        }
    }
}
