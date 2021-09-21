using System;

namespace FiguraGeometrica
{
    class Circulo
    {
        private double radio = 0;

        public double Radio
        {
            get { return radio; }
            set { radio = value; }
        }

        public Circulo(double radio = 1) 
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
