using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class Desarrollador : Empleado
    {
        const int BONIFICACION_POR_CERTIFICACION = 500;
        public int CertificacionActiva { get; set; }

        public override decimal CalcularBonificacion()
        {
            return base.CalcularBonificacion() + ((BONIFICACION_POR_CERTIFICACION * base._salarioBase) * CertificacionActiva);
        }

        public Desarrollador(string nombre, string departamento, decimal salarioBase, int CertificacionActiva) : base(nombre, departamento, salarioBase)
        {
            this.CertificacionActiva = CertificacionActiva;
        }
    }
}
