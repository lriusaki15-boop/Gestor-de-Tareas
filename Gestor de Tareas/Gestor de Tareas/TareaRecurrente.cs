using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class TareaRecurrente : Tarea
    {
        public int diasIntervalo { get; set; }
        public TareaRecurrente(int id, string titulo, DateTime fechaLimite, PrioridadTarea prioridad, string descripcion, int diasintervalo) : base(id, titulo, fechaLimite, prioridad, descripcion)
        {
            this.diasIntervalo = diasintervalo;
        }

        public void HacerTareaRegular(int intervaloDias)
        {
            if(Estado == EstadoTarea.Completada && Estado != EstadoTarea.Cancelada)
            {
                Iniciar();
                this.diasIntervalo = intervaloDias;
            }
        }

        public override string ObtenerResumen()
        {
            return $"Esta tarea con titulo: {this.Titulo} \n Fecha de Creacion: {this.FechaCreacion} \nDias de intervalo de la tarea regular:" +
                $"Fecha Limite: {this.FechaLimite} \n Dias restantes para finalizacion: {this.DiasRestantes} Dias " +
                $"\n Prioridad de la tarea: {this.Prioridad} \nDescripcion: {this.Descripcion}";
        }
    }
}
