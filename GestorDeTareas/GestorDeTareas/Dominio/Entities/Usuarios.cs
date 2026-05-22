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
        public string Contrasenia { get; set; } = string.Empty;
        public TipoUsuario Rango { get; set; }

        public Usuarios()
        {

        }

        public Usuarios(long id, string nombre, string apellidos, string contrasenia, TipoUsuario rango)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Contrasenia = contrasenia;
            this.Rango = rango;
        }
    }
}
