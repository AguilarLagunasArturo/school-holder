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
            char opcion;
            Empresa tamsa = new Empresa("TAMSA");
            do
            {
                Console.Clear();
                Console.WriteLine("Empresa {0} \n\nNumero de empleados : {1}\n", tamsa.Nombre, tamsa.Lista.Count());
                Console.WriteLine("[A] gregar Empleado");
                Console.WriteLine("[N] omina ");
                Console.WriteLine("[S] alir");

                Console.Write("\nElige una opcion: ");
                opcion = Console.ReadLine().ToUpper().ElementAt(0);

                switch (opcion)
                {
                    case 'A':
                        tamsa.Agregar();
                        break;
                    case 'N':
                        tamsa.Nomina();
                        break;
                    case 'S': break;

                    default:
                        Console.WriteLine("Opcion no valida ....");
                        break;
                }
            } while (opcion != 'S');
            
        }
    }
}
