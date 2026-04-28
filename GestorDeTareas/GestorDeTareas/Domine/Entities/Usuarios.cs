using System;
using System.Collections.Generic;
using System.Text;

namespace GestorDeTareas.Domine.Entities
{
    internal class Usuarios
    {
        public int Id { get; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Email { get; private set; }
        private string Contrasenia { get; set; }

        public Usuarios(int id, string nombre, string apellido, string contrasenia)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Contrasenia = contrasenia;
        }
    }
}
