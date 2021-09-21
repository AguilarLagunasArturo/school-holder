using System;

namespace FiguraGeometrica
{
    class Esfera
    {
        private double radio = 0;
        
        public Esfera(double radio = 1)
        {
            this.radio = radio;
        }

        public double Radio
        {
            get { return radio; }
            set { radio = value; }
        }

        public double Area()
        {
            return 4 * Math.PI * Math.Pow(radio, 2);
        }

        public double Volumen()
        {
            return (4 * Math.PI * Math.Pow(radio, 3)) / 3;
        }
    }
}
