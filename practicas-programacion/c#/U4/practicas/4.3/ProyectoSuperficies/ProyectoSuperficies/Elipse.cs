using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSuperficies
{
    class Elipse : Superficie
    {
        private double radioMenor;
        private double radioMayor;

        public double RadioMenor { get => radioMenor; set => radioMenor = value; }
        public double RadioMayor { get => radioMayor; set => radioMayor = value; }

        public Elipse(double radioMenor, double radioMayor)
        {
            this.radioMenor = radioMenor;
            this.radioMayor = radioMayor;
        }

        public double Area()
        {
            return Math.PI * radioMenor * radioMayor;
        }

        public double Perimetro()
        {
            return 2 * Math.PI * Math.Sqrt((Math.Pow(radioMenor, 2) + Math.Pow(radioMayor, 2)) / 2);
        }
    }
}
