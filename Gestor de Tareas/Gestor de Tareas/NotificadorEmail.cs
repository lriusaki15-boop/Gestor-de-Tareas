using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class NotificadorEmail : INotificable
    {
        public string SmtpServer { get; set; }
        public void Enviar(string asunto, string cuerpo)
        {
            if (EsDisponible())
            {
                Console.WriteLine($"Mensaje {ObtenerTipoCanal()} enviado");
            }
            else
            {
                Console.WriteLine($"Mensaje {ObtenerTipoCanal()} no enviado");
            }
        }

        public bool EsDisponible()
        {
            if (SmtpServer.IsWhiteSpace())
                return false;
            else return true;
        }

        public string ObtenerTipoCanal()
        {
            return "EMAIL";
        }

        public NotificadorEmail(string smtpServer) : base() => this.SmtpServer = smtpServer;
    }
}
