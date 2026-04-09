using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }

        public Persona(string nombre, int edad, string email)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.Email = email;
        }
    }
}
