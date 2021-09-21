using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEmpresa
{
    class EmpleadoBase : Empleado
    {
        protected double salarioBase;
        public double SalarioBase
        {
            get { return salarioBase; }
            set { salarioBase = value; }
        }

        // Constructor.
        public EmpleadoBase(string nombre = "", double salarioBase =
                                                        1000) : base(nombre)
        {
            this.salarioBase = salarioBase;
        }

        // Definición del método salario.
        public override double Salario()
        {
            return salarioBase;
        }
    }
}
