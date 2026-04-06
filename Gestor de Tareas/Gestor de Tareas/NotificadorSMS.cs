using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class NotificadorSMS : INotificable
    {
        public string ProveedorApi { get; set; }
        public string PrefijoPais { get; set; }
        public void Enviar(string asunto, string cuerpo)
        {

            string textoLimitado = cuerpo.Length > 160 ? cuerpo.Substring(0, 160) : cuerpo;

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
            if (ProveedorApi.IsWhiteSpace() || ProveedorApi.IsWhiteSpace()) return false;
            else return true;
        }

        public string ObtenerTipoCanal()
        {
            return "SMS";
        }

        public NotificadorSMS(string proveedorApi, string prefijoPais) : base()
        {
            this.ProveedorApi = proveedorApi;
            this.PrefijoPais = prefijoPais;
        }
    }
}
