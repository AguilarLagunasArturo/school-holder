using System;

namespace AplicacionFiguras
{
    class Program
    {
        static void Main(string[] args)
        {
            Circulo circulo = new Circulo(0, 0, 5);
            Cilindro cilindro = new Cilindro(0, 0, 5, 10);
            Cuadrado cuadrado = new Cuadrado(0, 0, 5);
            Cubo cubo = new Cubo(0, 0, 5);

            Console.WriteLine("El area del circulo es {0}", circulo.Area());
            Console.WriteLine("El volumen del cilindro es {0}", cilindro.Volumen());
            Console.WriteLine("El area del cilindro es {0}", cilindro.Area());
            Console.WriteLine("El area del cuadrado es {0}", cuadrado.Area());
            Console.WriteLine("El volumen del cubo es {0}", cubo.Volumen());

            Console.ReadKey();
        }
    }
}
