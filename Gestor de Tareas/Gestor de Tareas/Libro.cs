using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Xml.Serialization;


namespace Gestor_de_Tareas
{
    [Serializable]
    [XmlRoot("Libro")]
    public class Libro
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
        [XmlElement("Titulo")]
        public string Titulo { get; set; }
        [XmlElement("Autor")]
        public string Autor { get; set; }
        [XmlElement("Paginas")]
        public int Paginas { get; set; }
        [XmlElement("Disponible")]
        public bool Disponible { get; set; }

        public Libro()
        {

        }
        public Libro(int id, string titulo,string autor, int paginas, bool disponible)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Autor = autor;
            this.Paginas = paginas;
            this.Disponible = disponible;
        }
        
        
    }
}
