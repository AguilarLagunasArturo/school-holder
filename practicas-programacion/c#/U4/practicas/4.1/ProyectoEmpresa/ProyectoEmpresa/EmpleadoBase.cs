using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEmpresa
{
    class EmpleadoBase: Empleado
    {
        protected double salarioBase;

        public double SalarioBase { get => salarioBase; set => salarioBase = value; }

        public EmpleadoBase(string nombre, double salarioBase) : base(nombre)
        {
            this.salarioBase = salarioBase;
        }

        public double Salario()
        {
            return salarioBase;
        }

    }
}
