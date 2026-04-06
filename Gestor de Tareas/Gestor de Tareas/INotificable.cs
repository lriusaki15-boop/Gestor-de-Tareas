using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal interface INotificable
    {
        public void Enviar(string asunto, string cuerpo);
        public bool EsDisponible();
        public string ObtenerTipoCanal();
    }
}
