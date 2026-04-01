using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class Comercial : Empleado
    {
        const decimal VENTA_CERRADA = 0.02m;
        public int Ventas { get; set; }

        public override decimal CalcularBonificacion()
        {
            return base.CalcularBonificacion() + ((VENTA_CERRADA * base._salarioBase) * Ventas);
        }

        public Comercial(string nombre, string departamento, decimal salarioBase, int ventas) : base(nombre, departamento, salarioBase)
        {
            this.Ventas = ventas;
        }
    }
}
