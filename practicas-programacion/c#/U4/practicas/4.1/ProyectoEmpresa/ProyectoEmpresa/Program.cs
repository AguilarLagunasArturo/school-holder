using System;
using System.Linq;

namespace ProyectoEmpresa
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Empresa tamsa = new Empresa("Tamsa");

            char opcion;
            do
            {
                Console.Clear();

                Console.WriteLine("Empresa: {0}\tEmpleados: {1}\n", tamsa.Nombre, tamsa.Empleados.Count);

                Console.WriteLine("[A] gregar");
                Console.WriteLine("[N] omina");
                Console.WriteLine("[C] onsultar salario");
                Console.WriteLine("[E] liminar");
                Console.WriteLine("[S] alir");

                Console.Write("\nElige una opcion: ");
                opcion = Console.ReadLine().ToUpper().ElementAt(0);
                Console.WriteLine();

                switch (opcion)
                {
                    case 'A':
                        tamsa.Agregar();
                        break;
                    case 'N':
                        tamsa.Nomina();
                        Console.ReadKey();
                        break;
                    case 'C':
                        tamsa.ConsultarSalario();
                        Console.ReadKey();
                        break;
                    case 'E':
                        tamsa.Eliminar();
                        Console.ReadKey();
                        break;
                    case 'S':
                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 'S');
        }
    }
}
