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
            char zona;
            bool correcto = false;
            do
            {
                Console.Write("Zona Geografica del municipio [N, C, S]: ");
                zona = Console.ReadLine().ToUpper().ElementAt(0);
                if (zona == 'N' || zona == 'C' || zona == 'S')
                    correcto = true;
                else
                    Console.WriteLine("Zona Geografica incorrecta, inetenta de nuevo");
            } while (!correcto);
            estado.Municipios.Add(new Municipio(nombre, poblacion, zona));
        }
        public static void Eliminar()
        {
            Console.Write("Nombre del municipio a eliminar: ");
            string nombre1 = Console.ReadLine();
            bool encontrado = false;
            foreach (Municipio m in estado.Municipios)
            {
                if (nombre1 == m.Nombre)
                {
                    estado.Municipios.Remove(m);
                    Console.WriteLine("Se ha eliminado el  municipio: {0}", nombre1);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
                Console.WriteLine("El estado no cuenta con un municipio llamado {0}", nombre1);
        }
        static void Modificar()
        {
            Console.Write("Nombre del municipio a modificar: ");
            string nombre = Console.ReadLine();
            bool encontrado = false;
            for (int i = 0; i < estado.Municipios.Count; i++)
            {
                if (nombre.Equals(estado.Municipios[i].Nombre))
                {
                    Console.Write("Ingresa la nueva poblacion:");
                    estado.Municipios[i].Poblacion = Convert.ToInt32(Console.ReadLine());
                    encontrado = true;
                    Console.WriteLine("Se ha modificado el municipio");
                    break;
                }
            }
            if (!encontrado)
                Console.WriteLine("El estado no cuenta con un municipio llamado {0}", nombre);
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
        }
        static void Main(string[] args)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            char opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Estado: {0}\n", estado.Nombre);
                Console.WriteLine("[A] Agregar Municipio");
                Console.WriteLine("[E] Eliminar Municipio");
                Console.WriteLine("Consultas:");
                Console.WriteLine("\t[P] Poblacion en el estado");
                Console.WriteLine("\t[B] Poblacion de un municipio");
                Console.WriteLine("\t[M] Municipio con poblacion maxima");
                Console.WriteLine("\t[N] Municipio con poblacion minima");
                Console.WriteLine("[C] Modificar poblacion de un Municipio");
                Console.WriteLine("[L] Lista de Municipios por zona geografica");
                Console.WriteLine("[S] Salir\n");

                Console.Write("Elige una opcion: ");
                opcion = Console.ReadLine().ToUpper().ElementAt(0);
                switch (opcion) {
                    case 'A':
                        Agregar();
                        Console.ReadKey();
                        break;
                    case 'E':
                        Eliminar();
                        Console.ReadKey();
                        break;
                    case 'P':
                        Console.WriteLine("La poblacion en el estado es: {0}", estado.Poblacion());
                        Console.ReadKey();
                        break;
                    case 'B':
                        Buscar();
                        Console.ReadKey();
                        break;
                    case 'M':
                        estado.MunicipioPoblacionMaxima();
                        Console.ReadKey();
                        break;
                    case 'N':
                        estado.MunicipioPoblacionMinima();
                        Console.ReadKey();
                        break;
                    case 'L':
                        estado.ListaMunicipiosZonaGeografica();
                        Console.ReadKey();
                        break;
                    case 'C':
                        Modificar();
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
