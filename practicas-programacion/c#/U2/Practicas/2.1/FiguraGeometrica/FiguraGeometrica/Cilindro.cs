using System;

namespace FiguraGeometrica
{
    class Cilindro
    {
        private Circulo c;
        private double altura = 0;
        
        public Cilindro(double altura = 1, double radio = 1)
        {
            c = new Circulo(radio);
            this.altura = altura;
        }

        public double Radio
        {
            get { return c.Radio; }
            set { c.Radio = value; }
        }

        public double Altura
        {
            get { return altura; }
            set { altura = value; }
        }

        public double Area()
        {
            return 2 * c.Area() + c.Perimetro() * altura;
        }

        public double Volumen()
        {
            return c.Area() * altura;
        }
    }
}
