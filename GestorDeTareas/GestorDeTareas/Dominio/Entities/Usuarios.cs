using System;
using System.Collections.Generic;
using System.Text;
using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Dominio.Entities
{
    public class Usuarios
    {
        public long Id { get; set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Email { get; private set; }
        public string ContraseniaHash { get; set; } = string.Empty;
        public TipoUsuario Rango { get; set; }

        public Usuarios()
        {

        }

        public Usuarios(int id, string nombre, string apellido, string contrasenia, TipoUsuario rango)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.ContraseniaHash = contrasenia;
            this.Rango = rango;
        }
    }
}
