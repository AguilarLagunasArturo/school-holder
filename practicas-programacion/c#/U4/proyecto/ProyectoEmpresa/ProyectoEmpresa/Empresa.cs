using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoEmpresa
{
    class Empresa
    {
        // Atributos
        private string nombre;
        private List<Empleado> lista;

        // Propiedades
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        internal List<Empleado> Lista
        {
            get { return lista; }
            set { lista = value; }
        }

        // Constructor
        public Empresa(string nombre)
        {
            this.nombre = nombre;
            lista = new List<Empleado>();
        }

        // Funciones
        public void Agregar()
        {
            Console.Clear();
            Console.WriteLine("Datos del empleado.\n");
            Empleado empleado = null;
            //  Console.Clear();
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("\n[B] ase ");
            Console.WriteLine("[J] ornada ");
            Console.WriteLine("[S] indicalizado");

            Console.Write("\nElige una opcion: ");
            char opcion = Console.ReadLine().ToUpper().ElementAt(0);

            switch (opcion)
            {
                case 'B':
                    {
                        Console.Write("Salario Base : ");
                        int salario = Convert.ToInt32(Console.ReadLine());
                        empleado = new EmpleadoBase(nombre, salario);
                        break;
                    }
                case 'J':
                    {
                        Console.Write("Dias Laborados : ");
                        int dias = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Salario por dia : ");
                        double salarioXDia = Convert.ToDouble(Console.ReadLine());
                        empleado = new EmpleadoJornada(nombre, dias, salarioXDia);
                        break;
                    }
                case 'S':
                    {
                        Console.Write("Salario Base : ");
                        int salario = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Horas extra : ");
                        int horas = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Salario por hora extra : ");
                        double salarioHora = Convert.ToDouble(Console.ReadLine());
                        empleado = new EmpleadoSindicalizado(nombre, salario, horas, salarioHora);
                        break;
                    }
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
            if (empleado != null)
                lista.Add(empleado);

            Console.WriteLine("\n\nPresione alguna tecla para continuar");
            Console.ReadKey();
        }

        public void Eliminar()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            bool eliminado = false;
            foreach (Empleado e in lista)
            {
                if (e.Nombre.Equals(nombre))
                {
                    lista.Remove(e);
                    eliminado = true;
                    break;
                }
            }

            if (eliminado)
                Console.WriteLine("\nSe ha eliminado a {0}", nombre);
            else
                Console.WriteLine("\nNo se encuentra el nombre '{0}'", nombre);

            Console.WriteLine("\n\nPresione alguna tecla para continuar");
            Console.ReadKey();
        }

        public void Modificar()
        {
            Console.Write("Nombre del empleado a modificar: ");
            string nombre = Console.ReadLine();
            bool encontrado = false;

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Nombre.Equals(nombre))
                {
                    encontrado = true;

                    Console.WriteLine("\n[B] ase ");
                    Console.WriteLine("[J] ornada ");
                    Console.WriteLine("[S] indicalizado");

                    Console.Write("\nElige una opcion: ");
                    char opcion = Console.ReadLine().ToUpper().ElementAt(0);

                    switch (opcion)
                    {
                        case 'B':
                            {
                                Console.Write("Salario Base : ");
                                int salario = Convert.ToInt32(Console.ReadLine());
                                lista[i] = new EmpleadoBase(lista[i].Nombre, salario);
                                break;
                            }
                        case 'J':
                            {
                                Console.Write("Dias Laborados : ");
                                int dias = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Salario por dia : ");
                                double salarioXDia = Convert.ToDouble(Console.ReadLine());
                                lista[i] = new EmpleadoJornada(lista[i].Nombre, dias, salarioXDia);
                                break;
                            }
                        case 'S':
                            {
                                Console.Write("Salario Base : ");
                                int salario = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Horas extra : ");
                                int horas = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Salario por hora extra : ");
                                double salarioHora = Convert.ToDouble(Console.ReadLine());
                                lista[i] = new EmpleadoSindicalizado(lista[i].Nombre, salario, horas, salarioHora);
                                break;
                            }
                        default:
                            Console.WriteLine("Opcion no valida");
                            break;
                    }
                    break;
                }
            }
            if (encontrado)
                Console.WriteLine("\nSe ha modificado el empleado: {0}", nombre);
            else
                Console.WriteLine("\nNo se encuentra el nombre '{0}'", nombre);

            Console.WriteLine("\n\nPresione alguna tecla para continuar");
            Console.ReadKey();
        }

        public void Nomina()
        {
            Console.Clear();
            Console.WriteLine("Empresa       : " + nombre + "\n\n");
            Console.WriteLine("{0,-20} {1,10} {2,25}", "Nombre", "Salario", "Tipo de Empleado");
            foreach (Empleado empleado in lista)
                Console.WriteLine("{0,-20} {1,10}\t{2,25}", empleado.Nombre, empleado.Salario(), empleado.GetType().Name);
            Console.Write("\n\nPresione alguna tecla para continuar");
            Console.ReadKey();
        }

    }
}
