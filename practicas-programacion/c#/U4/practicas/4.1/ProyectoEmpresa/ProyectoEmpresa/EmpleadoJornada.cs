using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEmpresa
{
    class EmpleadoJornada : Empleado
    {
        protected int numeroDias;
        protected double salarioXDia;

        public int NumeroDias { get => numeroDias; set => numeroDias = value; }
        public double SalarioXDia { get => salarioXDia; set => salarioXDia = value; }

        public EmpleadoJornada(string nombre, int numeroDias, double salarioXDia) : base(nombre)
        {
            this.numeroDias = numeroDias;
            this.salarioXDia = salarioXDia;
        }

        public double Salario()
        {
            return salarioXDia * numeroDias;
        }
    }
}
