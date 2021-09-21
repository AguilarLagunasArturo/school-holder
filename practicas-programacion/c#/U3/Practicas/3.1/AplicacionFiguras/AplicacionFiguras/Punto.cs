using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionFiguras
{
    class Punto
    {
        protected double x;
        protected double y;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public Punto(double x = 0.0, double y = 0.0)
        {
            this.x = x;
            this.y = y;
        }
    }
}
