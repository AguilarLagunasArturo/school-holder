using System;

namespace Rectangulos
{
    class Punto
    {
        private double x;
        private double y;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public Punto(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
