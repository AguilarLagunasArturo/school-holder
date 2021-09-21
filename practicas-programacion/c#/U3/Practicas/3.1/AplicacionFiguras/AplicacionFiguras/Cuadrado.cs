using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionFiguras
{
    class Cuadrado: Punto
    {
        protected double lado;

        private double Lado { get => lado; set => lado = value; }

        public Cuadrado(double x = 0.0, double y = 0.0, double lado = 0.0) : base(x, y)
        {
            this.lado = lado;
        }
        public double Area()
        {
            return lado * lado;
        }
    }
}
