using System;

namespace FiguraGeometrica
{
    class Program
    {
        static void Main(string[] args)
        {
            Circulo circulo = new Circulo();
            Cilindro cilindro = new Cilindro();
            Esfera esfera = new Esfera();

            // Console.WriteLine("El perimetro del circulo es: {0}", circulo.Perimetro());
            // Console.ReadKey();

            // Console.WriteLine("El area del circulo es: {0}", circulo.Area());
            // Console.WriteLine("El area del circulo es: {0}", circulo.Area().ToString("F0"));
            // Console.ReadKey();

            // ITERATIVO
            Console.WriteLine("MENU:");
            Console.WriteLine("\t1: Interactuar con Circulo.");
            Console.WriteLine("\t2: Interactuar con Cilindro.");
            Console.WriteLine("\t3: Interactuar con Esfera.");
            Console.WriteLine("\t0: Salir.\n");
            bool enLoop = true;
            do {
                Console.Write("\nElige una opcion del menu: ");
                switch (Convert.ToInt32(Console.ReadLine())) {
                    case 0:
                        enLoop = false;
                        break;
                    case 1:
                        Console.Write("Introduce el valor del radio: ");
                        circulo.Radio = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("El area del circulo es: {0}", circulo.Area());
                        Console.WriteLine("El perimetro del circulo es: {0}", circulo.Perimetro());
                        break;
                    case 2:
                        Console.Write("Introduce el valor del radio: ");
                        cilindro.Radio = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Introduce el valor de la altura: ");
                        cilindro.Altura = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("El area total del cilindro es {0}", cilindro.Area());
                        Console.WriteLine("El volumen del cilindro es: {0}", cilindro.Volumen());
                        break;
                    case 3:
                        Console.Write("Introduce el valor del radio: ");
                        esfera.Radio = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("El area total de la esfera es: {0}", esfera.Area());
                        Console.WriteLine("El volumen de la esfera es: {0}", esfera.Volumen());
                        break;
                    default:
                        Console.WriteLine("Opcion invalida, intenta de nuevo.");
                        break;
                }
            } while (enLoop);
        }
    }
}
