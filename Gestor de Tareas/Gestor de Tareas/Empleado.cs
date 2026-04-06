using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class Empleado
    {
        const decimal DESCUENTO_BASE = 0.5m;
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        protected decimal _salarioBase;

        public virtual decimal ObtenerSalario()
        {
            return _salarioBase;
        }

        public virtual decimal CalcularBonificacion()
        {
            return _salarioBase * DESCUENTO_BASE;
        }

        public Empleado(string nombre, string departamento, decimal salarioBase)
        {
            this.Nombre = nombre;
            this.Departamento = departamento;
            this._salarioBase = salarioBase;
        }
    }
}
