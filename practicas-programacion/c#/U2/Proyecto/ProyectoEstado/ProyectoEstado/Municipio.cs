using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoEstado
{
    class Municipio
    {
        private string nombre;
        private int poblacion;
        private char zonaGeografica;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Poblacion { get => poblacion; set => poblacion = value; }
        public char ZonaGeografica { get => zonaGeografica; set => zonaGeografica = value; }

        public Municipio(string nombre, int poblacion, char zonaGeografica)
        {
            this.nombre = nombre;
            this.poblacion = poblacion;
            this.zonaGeografica = zonaGeografica; 
        }
    }
}
