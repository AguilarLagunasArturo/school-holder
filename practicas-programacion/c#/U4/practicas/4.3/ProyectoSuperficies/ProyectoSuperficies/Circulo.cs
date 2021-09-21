using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSuperficies
{
    class Circulo : Superficie
    {
        private double radio;

        public double Radio { get => radio; set => radio = value; }

        public Circulo(double radio = 1.0)
        {
            this.radio = radio;
        }

        public double Area()
        {
            return Math.PI * Math.Pow(radio, 2);
        }

        public double Perimetro()
        {
            return 2 * Math.PI * radio;
        }
    }
}
