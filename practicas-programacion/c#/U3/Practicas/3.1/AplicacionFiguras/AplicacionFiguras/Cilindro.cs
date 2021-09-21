using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AplicacionFiguras
{
    class Cilindro : Circulo
    {
        private double largo;
        

        public double Largo { get => largo; set => largo = value; }

        public Cilindro(double x = 0.0, double y = 0.0, double radio = 0.1, double largo = 1.0) : base(x, y, radio)
        {
            this.largo = largo;
        }

        public double Volumen()
        {
            return base.Area() * largo;
        }
        
        public new double Area()
        {
            return 2 * base.Area() + base.Perimetro() * largo;
        }
    }
}
