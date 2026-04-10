using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class TareaConSubtareas : Tarea
    {
        private List<TareaSimple> _subtareas = new();

        public TareaConSubtareas(int id, string titulo, DateTime fechaLimite, PrioridadTarea prioridad, string descripcion, List<TareaSimple> subtarea) : base(id, titulo, fechaLimite, prioridad, descripcion)
        {
            this._subtareas = subtarea;
        }

        public void AgregarSubtarea(TareaSimple subtarea) => _subtareas.Add(subtarea);

        public override string ObtenerResumen()
        {
            return $"Esta tarea con titulo: {this.Titulo} \n Fecha de Creacion: {this.FechaCreacion} \n Fecha Limite: {this.FechaLimite} \n Dias restantes para finalizacion: {this.DiasRestantes} Dias " +
                $"\n Prioridad de la tarea: {this.Prioridad} \n" +
                $"Descripcion: {this.Descripcion}";
        }
    }
}
