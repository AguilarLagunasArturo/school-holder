using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionFiguras
{
    class Circulo : Punto
    {
        protected double radio;

        public double Radio { get => radio; set => radio = value; }

        public Circulo(double x = 0.0, double y = 0.0, double radio = 0.1) : base(x, y)
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
