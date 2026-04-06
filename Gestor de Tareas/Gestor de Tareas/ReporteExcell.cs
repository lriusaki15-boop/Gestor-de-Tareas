using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class ReporteExcell : Generador_Reporte
    {
        const string EXTENSION_EXCELL = "excell";
        public ReporteExcell(string TitularArchivo) : base(TitularArchivo)
        {
        }

        public override string ObtenerCabecera()
        {
            return "datos de .excell";
        }

        public override string ObtenerExtension()
        {
            return EXTENSION_EXCELL;
        }

        public override string RenderizarCuerpo(int filas)
        {
            return "Cuerpo de .PDF renderizado con " + filas;
        }

        public override bool Generar(int filas)
        {
            bool generadoCorrecto = base.Generar(filas);
            Console.WriteLine($"La extension del archivo es: {ObtenerExtension()}");
            Console.WriteLine(ObtenerCabecera());
            Console.WriteLine(RenderizarCuerpo(filas));
            return true;

        }
    }
}
