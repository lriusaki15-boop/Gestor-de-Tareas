using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class TareaConSubtareas : Tarea
    {
        private readonly List<TareaSimple> _subtareas = new();

        public TareaConSubtareas(int id, string titulo, DateTime fechaLimite, PrioridadTarea prioridad, string descripcion) : base(id, titulo, fechaLimite, prioridad, descripcion)
        {
        }

        public void AgregarSubtarea(TareaSimple subtarea) => _subtareas.Add(subtarea);

        public int TotalSubtareas => _subtareas.Count;
        public int SubtareasCompletadas => _subtareas.Count(tareaSimpleSubtarea => tareaSimpleSubtarea.Estado == EstadoTarea.Completada);

        public override string ObtenerResumen()
        {
            return $"Esta tarea con titulo: {this.Titulo} \n Fecha de Creacion: {this.FechaCreacion} \n Fecha Limite: {this.FechaLimite} \n Dias restantes para finalizacion: {this.DiasRestantes} Dias " +
                $"\n Prioridad de la tarea: {this.Prioridad} \n" +
                $"Descripcion: {this.Descripcion} /nSubtareas {SubtareasCompletadas}/{TotalSubtareas} | {Estado}";
        
        }
    }
}
