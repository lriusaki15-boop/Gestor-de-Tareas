using System;
using System.Collections.Generic;
using System.Text;

namespace Gestor_de_Tareas
{
    internal class EmpleadoPorHoras : Empleado 
    {
        public int HorasTrabajadas { get; set; }
        public decimal TarifaHora { get; set; }


        public override decimal ObtenerSalario()
        {
            return HorasTrabajadas * TarifaHora;
        }

        public EmpleadoPorHoras(string nombre, string departamento, decimal salarioBase, int horasTrabajadas, decimal tarifaHora):base(nombre, departamento,salarioBase)
        {
            this.HorasTrabajadas = horasTrabajadas;
            this.TarifaHora = tarifaHora;
        }
    }
}
