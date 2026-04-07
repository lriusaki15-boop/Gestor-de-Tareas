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

        public override string ObtenerResumen()
        {
            return $"Esta tarea con titulo: {this.Titulo} \n Fecha de Creacion: {this.FechaCreacion} \n Fecha Limite: {this.FechaLimite} \n Dias restantes para finalizacion: {this.DiasRestantes} Dias " +
                $"\n Prioridad de la tarea: {this.Prioridad} \n Responsable de la tarea: {this.Responsable}" +
                $"Descripcion: {this.Descripcion}";
        }
    }
}
