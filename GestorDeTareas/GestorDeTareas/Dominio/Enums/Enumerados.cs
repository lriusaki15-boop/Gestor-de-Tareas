using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeTareas.Dominio.Enums
{
    public class Enumerados
    {
        public enum PrioridadTarea { Baja, Media, Alta }
        public enum EstadoTarea { Pendiente, EnProgreso, Completada, Cancelada }
        public enum TipoUsuario { Admin, Trabajador, Cliente}
    }
}
