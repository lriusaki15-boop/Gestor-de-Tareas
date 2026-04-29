using System;
using System.Collections.Generic;
using System.Text;
using static GestorDeTareas.Domine.Enums.Enumerados;

namespace GestorDeTareas.Domine.Entities
{
    public class Usuarios
    {
        public int Id { get; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Email { get; private set; }
        private string Contrasenia { get; set; }
        public TipoUsuario Rango { get; set; }

        public Usuarios(int id, string nombre, string apellido, string contrasenia, TipoUsuario rango)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Contrasenia = contrasenia;
            this.Rango = rango;
        }
    }
}
