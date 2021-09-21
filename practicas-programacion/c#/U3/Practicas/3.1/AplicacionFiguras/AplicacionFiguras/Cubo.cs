using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionFiguras
{
    class Cubo: Cuadrado
    {
        public double Volumen()
        {
            return base.Area() * lado;
        }

        public Cubo(double x = 0.0, double y = 0.0, double lado = 0.0) : base(x, y, lado) { }
    }
}
