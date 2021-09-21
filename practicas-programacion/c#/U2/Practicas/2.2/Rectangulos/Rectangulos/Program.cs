using System;

namespace Rectangulos
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3 objetos, solicitar valores que los definen
            Console.WriteLine("Ingresa las coordenadas para definir los rectagulos.\n");
            // Constructor vacio
            RectanguloGrafico r1 = new RectanguloGrafico(); // vacio
            Console.WriteLine("Rectagulo 1:");
            Console.Write("x1: ");
            r1.P1.X = Convert.ToDouble(Console.ReadLine());
            Console.Write("y1: ");
            r1.P1.Y = Convert.ToDouble(Console.ReadLine());
            Console.Write("x2: ");
            r1.P2.X = Convert.ToDouble(Console.ReadLine());
            Console.Write("y2: ");
            r1.P2.Y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("El area del rectangulo 1 es: {0}\n", r1.Area());
            // Por coordenadas
            RectanguloGrafico r2; 
            double x1, x2, y1, y2;
            Console.WriteLine("Rectagulo 2:");
            Console.Write("x1: ");
            x1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("y1: ");
            y1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("x2: ");
            x2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("y2: ");
            y2 = Convert.ToDouble(Console.ReadLine());
            r2 = new RectanguloGrafico(x1, y1, x2, y2);
            Console.WriteLine("El area del rectangulo 2 es: {0}\n", r2.Area());

            // Recibe dos objetos de la clase Punto
            Console.WriteLine("Rectagulo 3:");
            Console.Write("x1: ");
            x1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("y1: ");
            y1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("x2: ");
            x2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("y2: ");
            y2 = Convert.ToDouble(Console.ReadLine());
            Punto p1 = new Punto(x1, y1);
            Punto p2 = new Punto(x2, y2);
            RectanguloGrafico r3 = new RectanguloGrafico(p1, p2);
            Console.WriteLine("El area del rectangulo 3 es: {0}\n", r3.Area());
            
            Console.ReadKey();
        }
    }
}
