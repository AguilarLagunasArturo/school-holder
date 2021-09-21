using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventanas
{
    public class Alumno
    {
        private string nombre;
        private double calificacion;

        public double Calificacion { get => calificacion; set => calificacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Alumno(string nombre, double calificacion)
        {
            this.nombre = nombre;
            this.calificacion = calificacion;
        }
    }
}
