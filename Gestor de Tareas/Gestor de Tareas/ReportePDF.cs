using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class ReportePDF : Generador_Reporte
    {
        const string EXTENSION_PDF = "PDF";
        public override string ObtenerCabecera()
        {
            return "datos de .PDF";
        }

        public override string ObtenerExtension()
        {
            
            return EXTENSION_PDF;

        }

        public override string RenderizarCuerpo(int filas)
        {
            return "Cuerpo de .PDF renderizado con "+filas;
        }

        public override bool Generar(int filas)
        {
            bool generadoCorrecto = base.Generar(filas);
            Console.WriteLine($"La extension del archivo es: {ObtenerExtension()}");
            Console.WriteLine(ObtenerCabecera());
            Console.WriteLine(RenderizarCuerpo(filas));
            return true;

        }
        public ReportePDF(string TitularArchivo) : base(TitularArchivo)
        {

        }
    }
}
