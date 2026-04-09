using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class TarearUrgente : Tarea
    {
        public string Responsable { get; set; }
        public TarearUrgente(int id, string titulo, DateTime fechaLimite, PrioridadTarea prioridad, string descripcion, string responsable) : base(id, titulo, fechaLimite, prioridad, descripcion)
        {
            this.Responsable = responsable;
        }

        public bool HacerTareaUrgente(string responsable)
        {
            if (string.IsNullOrEmpty(this.Responsable)) throw new ArgumentException("A la tarea le falta asignarle un responsable");
            if (Estado != EstadoTarea.Completada && Estado != EstadoTarea.Cancelada)
            {
                this.Prioridad = PrioridadTarea.Alta;
            }

            return false;
        }

        public override string ObtenerResumen()
        {
            return $"Esta tarea con titulo: {this.Titulo} \n Fecha de Creacion: {this.FechaCreacion} \n Fecha Limite: {this.FechaLimite} \n Dias restantes para finalizacion: {this.DiasRestantes} Dias " +
                $"\n Prioridad de la tarea: {this.Prioridad} \n Responsable de la tarea: {this.Responsable}" +
                $"Descripcion: {this.Descripcion}";
        }
    }
}
