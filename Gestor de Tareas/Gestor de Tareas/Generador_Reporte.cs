using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal abstract class Generador_Reporte
    {
        public string tituloArchivo { get; set; }

        public abstract string ObtenerCabecera();
        public abstract string RenderizarCuerpo(int filas);
        public abstract string ObtenerExtension();
        public virtual bool Generar(int filas) { return false; }
        protected Generador_Reporte(string TitularArchivo) { tituloArchivo = TitularArchivo; }
    }
}
