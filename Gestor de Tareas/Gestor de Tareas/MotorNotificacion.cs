using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class MotorNotificacion
    {
        public void EnviarATodos(List<INotificable> notificables, string asunto, string cuerpo)
        {
            foreach (var notificable in notificables)
                if (notificable.EsDisponible())
                {
                    notificable.Enviar(asunto, cuerpo);
                    Console.WriteLine($"Se va a enviar {notificable.ObtenerTipoCanal()} | a sido posible: SI");
                }
                else
                {
                    Console.WriteLine($"Se va a enviar {notificable.ObtenerTipoCanal()} | a sido posible: NO");
                }
        }
    }
}
