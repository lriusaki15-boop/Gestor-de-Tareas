using GestorDeTareas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class TareaAction : Tarea
    {
        public TareaAction(int id, string titulo, string descripcion, string responsable, DateTime fechaLimite, DateTime fechaCreacion, PrioridadTarea prioridad, EstadoTarea estado) : base(id, titulo, descripcion, responsable, fechaLimite,fechaCreacion, prioridad, estado)
        {
        }

        public override string ObtenerResumen()
        {
            throw new NotImplementedException();
        }
    }
}
