using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class TareaSimple : Tarea
    {
        public DateTime FechaFinTarea { get; }
        public TareaSimple(int id, string titulo, DateTime fechaLimite, PrioridadTarea prioridad, string descripcion, DateTime fechafintarea) : base(id, titulo, fechaLimite, prioridad, descripcion)
        {
            this.FechaFinTarea = fechafintarea;
        }

        public override string ObtenerResumen()
        {
            return $"Esta tarea con titulo: {this.Titulo} \n Fecha de Creacion: {this.FechaCreacion} \n Fecha Limite: {this.FechaLimite} \n Fecha fin de tarea: {this.FechaFinTarea} \n Prioridad de la tarea: {this.Prioridad} \n" +
                $"Descripcion: {this.Descripcion}";

        }
    }
}
