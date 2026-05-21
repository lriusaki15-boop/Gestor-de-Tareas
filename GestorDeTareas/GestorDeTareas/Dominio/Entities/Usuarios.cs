using System;
using System.Collections.Generic;
using System.Text;
using static GestorDeTareas.Dominio.Enums.Enumerados;

namespace GestorDeTareas.Dominio.Entities
{
    public class Usuarios
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string ContraseniaHash { get; set; } = string.Empty;
        public TipoUsuario Rango { get; set; }

        public Usuarios()
        {

        }

        public Usuarios(int id, string nombre, string apellidos, string contrasenia, TipoUsuario rango)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.ContraseniaHash = contrasenia;
            this.Rango = rango;
        }
    }
}
