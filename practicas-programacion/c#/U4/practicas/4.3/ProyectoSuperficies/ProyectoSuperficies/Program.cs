using System;
using System.Collections.Generic;

namespace ProyectoSuperficies
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Superficie> objetos = new List<Superficie>();

            objetos.Add(new Circulo(5.0));
            objetos.Add(new Rectangulo(10.0, 20.0));
            objetos.Add(new Circulo(7.0));
            objetos.Add(new Trapecio(7.0, 20.0, 5.0));
            objetos.Add(new Elipse(2.5, 5.0));

            foreach (Superficie s in objetos)
                Console.WriteLine("El area del {0} es: \t{1}", s.GetType().Name, s.Area());

            Console.ReadKey();
        }
    }
}
