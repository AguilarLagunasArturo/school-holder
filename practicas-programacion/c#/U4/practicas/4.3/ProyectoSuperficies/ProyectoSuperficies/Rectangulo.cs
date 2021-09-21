using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSuperficies
{
    class Rectangulo : Superficie
    {
        private double largo;
        private double ancho;

        public double Largo { get => largo; set => largo = value; }
        public double Ancho { get => ancho; set => ancho = value; }

        public Rectangulo(double largo = 1.0, double ancho = 1.0)
        {
            this.largo = largo;
            this.ancho = ancho;
        }

        public double Area()
        {
            return largo * ancho;
        }

        public double Perimetro()
        {
            return 2 * (largo + ancho);
        }
    }
}
