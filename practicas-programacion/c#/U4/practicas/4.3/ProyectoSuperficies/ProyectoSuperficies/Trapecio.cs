using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSuperficies
{
    class Trapecio : Superficie
    {
        private double ladoMenor;
        private double ladoMayor;
        private double altura;

        public double LadoMenor { get => ladoMenor; set => ladoMenor = value; }
        public double LadoMayor { get => ladoMayor; set => ladoMayor = value; }
        public double Altura { get => altura; set => altura = value; }

        public Trapecio(double ladoMenor, double ladoMayor, double altura)
        {
            this.ladoMenor = ladoMenor;
            this.ladoMayor = ladoMayor;
            this.altura = altura;
        }

        public double Area()
        {
            return ((ladoMayor + ladoMenor) * altura) / 2;
        }

        public double Perimetro()
        {
            return ladoMenor + ladoMayor + 2 * (Math.Sqrt(Math.Pow((ladoMayor - ladoMenor), 2) + Math.Pow(altura, 2)));
        }
    }
}
