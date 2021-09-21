using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEmpresa
{
    class Empleado
    {
        protected string nombre;

        public string Nombre { get => nombre; set => nombre = value; }

        public Empleado(string nombre)
        {
            this.nombre = nombre;
        }
    }
}
