using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEstado
{
    class Municipio
    {
        private string nombre;
        private int poblacion;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Poblacion { get => poblacion; set => poblacion = value; }

        public Municipio(string nombre, int poblacion)
        {
            this.nombre = nombre;
            this.poblacion = poblacion;
        }
    }
}
