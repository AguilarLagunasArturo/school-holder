using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEmpresa
{
    class EmpleadoSindicalizado : EmpleadoBase
    {
        protected int horasExtra;
        protected double salarioHorasExtra;

        public int HorasExtra { get => horasExtra; set => horasExtra = value; }
        public double SalarioHorasExtra { get => salarioHorasExtra; set => salarioHorasExtra = value; }

        public EmpleadoSindicalizado(string nombre, double salarioBase, int horasExtra, double salarioHorasExtra) : base(nombre, salarioBase)
        {
            this.horasExtra = horasExtra;
            this.salarioHorasExtra = salarioHorasExtra;
        }

        public override double Salario()
        {
            return base.salarioBase + (horasExtra * salarioHorasExtra);
        }
    }
}
