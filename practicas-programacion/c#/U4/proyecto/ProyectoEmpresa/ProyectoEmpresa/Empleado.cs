using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEmpresa
{
    abstract class Empleado
    {
        protected string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Empleado(string nombre)
        {
            this.nombre = nombre;
        }

        //Método absttracto.
        public abstract double Salario();

    }
}
