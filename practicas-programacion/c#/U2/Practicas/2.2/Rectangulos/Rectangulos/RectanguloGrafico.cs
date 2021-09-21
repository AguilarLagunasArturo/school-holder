using System;

namespace Rectangulos
{
    class RectanguloGrafico
    {
        // Atributos
        private Punto p1;
        private Punto p2;

        internal Punto P1 { get => p1; set => p1 = value; }

        internal Punto P2 { get => p2; set => p2 = value; }

        // Constructores
        public RectanguloGrafico()
        {
            p1 = new Punto(0.0, 0.0);
            p2 = new Punto(0.0, 0.0);
        }
        public RectanguloGrafico(double x1, double y1, double x2, double y2)
        {
            p1 = new Punto(x1, y1);
            p2 = new Punto(x2, y2);
        }
        public RectanguloGrafico(Punto p1, Punto p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        // Funciones
        public double Ancho()
        {
            return Math.Abs(p2.X - p1.X);
        }
        public double Alto()
        {
            return Math.Abs(p2.Y - p1.Y);
        }
        public double Area()
        {
            return Ancho() * Alto();
        }
    }
}
