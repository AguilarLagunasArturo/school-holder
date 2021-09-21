using System;
using System.Linq;

namespace ProyectoEstado
{
    class Program
    {
        private static Estado estado = new Estado("Veracruz");
        public static void Agregar()
        {
            Console.Write("Nombre del municipio: ");
            string nombre = Console.ReadLine();
            Console.Write("Poblacion del municipio: ");
            int poblacion = Convert.ToInt32(Console.ReadLine());
            estado.Municipios.Add( new Municipio(nombre, poblacion) );
        }
        public static void Buscar()
        {
            Console.Write("Nombre del municipio: ");
            string buscarMunicipio = Console.ReadLine();
            bool encontrado = false;
            foreach (Municipio m in estado.Municipios)
            {
                if (m.Nombre.Equals(buscarMunicipio))
                {
                    Console.WriteLine("{0}:\tPoblacion: {1}", m.Nombre, m.Poblacion);
                    encontrado = true;
                }
            }
            if (!encontrado)
                Console.WriteLine("El estado no cuenta con un municipio llamado {0}", buscarMunicipio);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            char opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Estado: {0}\n", estado.Nombre);
                Console.WriteLine("[A] gregar Municipio");
                Console.WriteLine("[B] uscar Municipio");
                Console.WriteLine("[L] ista de Municipios");
                Console.WriteLine("[M] unicipio con poblacion maxima");
                Console.WriteLine("[P] Municipios con poblacion menor al promedio");
                Console.WriteLine("[S] alir\n");
                opcion = Console.ReadLine().ToUpper().ElementAt(0);
                switch (opcion) {
                    case 'A':
                        Agregar();
                        break;
                    case 'B':
                        Buscar();
                        break;
                    case 'L':
                        estado.ListaMunicipios();
                        break;
                    case 'M':
                        estado.MunicipioPoblacionMaxima();
                        Console.ReadKey();
                        break;
                    case 'P':
                        estado.MustraMunicipiosPoblacionMenorAlPromedio();
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
