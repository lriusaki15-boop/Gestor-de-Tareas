using GestorDeTareas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class TareaAction : Tarea
    {
        public TareaAction(int id, string titulo, string descripcion, string responsable, DateTime fechaCreacion, DateTime fechaLimite, DateTime? fechaFinTarea, PrioridadTarea prioridad, EstadoTarea estado, string? motivacionCancelacion, List<TareaDto>? subTareas) : base(id, titulo, descripcion, responsable,fechaCreacion, fechaLimite, prioridad, estado, motivacionCancelacion, subTareas)
        {
        }

        public override string ObtenerResumen()
        {
            throw new NotImplementedException();
        }
    }
}
