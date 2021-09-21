using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoEmpresa
{
    class Empresa
    {
        protected string nombre;
        protected List<Empleado> empleados;

        public string Nombre { get => nombre; set => nombre = value; }
        internal List<Empleado> Empleados { get => empleados; set => empleados = value; }

        public Empresa(string nombre)
        {
            this.nombre = nombre;
            empleados = new List<Empleado>();
        }

        public void Agregar()
        {
            char opcion;
            Console.Clear();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("[B] ase");
            Console.WriteLine("[J] ornada");
            Console.WriteLine("[S] indicalizado");

            Empleado empleado = null;

            Console.Write("\nElige un tipo de empleado: ");
            opcion = Console.ReadLine().ToUpper().ElementAt(0);
            Console.WriteLine();

            double salarioBase;

            switch (opcion)
            {
                case 'B':
                    Console.Write("Salario base: ");
                    salarioBase = Convert.ToDouble(Console.ReadLine());
                    empleado = new EmpleadoBase(nombre, salarioBase);
                    break;
                case 'J':
                    Console.Write("Dias laborados: ");
                    int dias = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Salario por dia: ");
                    double salarioDia = Convert.ToDouble(Console.ReadLine());
                    empleado = new EmpleadoJornada(nombre, dias, salarioDia);
                    break;
                case 'S':
                    Console.Write("Salario base: ");
                    salarioBase = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Horas extra: ");
                    int horasExtra = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Salario por hora extra: ");
                    double salarioHoraExtra = Convert.ToDouble(Console.ReadLine());
                    empleado = new EmpleadoSindicalizado(nombre, salarioBase, horasExtra, salarioHoraExtra);
                    break;
                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }

            if (empleado != null)
            {
                empleados.Add(empleado);
            }
        }

        public void ConsultarSalario()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            bool encontrado = false;
            foreach (Empleado empleado in empleados)
            {
                if (empleado.Nombre.Equals(nombre))
                {
                    if (empleado is EmpleadoBase)
                    {
                        if (empleado is EmpleadoSindicalizado)
                            Console.WriteLine("Salario:\t${0, 10}", ((EmpleadoSindicalizado)empleado).Salario());
                        else
                            Console.WriteLine("Salario:\t${0, 10}", ((EmpleadoBase)empleado).Salario());
                    }
                    else
                        Console.WriteLine("Salario:\t${0, 10}", ((EmpleadoJornada)empleado).Salario());
                    encontrado = true;
                }
            }
            if (!encontrado)
                Console.WriteLine("\nNo se ha encontrado a {0}", nombre);
        }

        public void Eliminar()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            bool eliminado = false;
            foreach (Empleado empleado in empleados)
            {
                if (empleado.Nombre.Equals(nombre))
                {
                    empleados.Remove(empleado);
                    eliminado = true;
                    break;
                }
            }
            if (eliminado)
                Console.WriteLine("\nSe ha eliminado a {0}", nombre);
            else
                Console.WriteLine("\nNo se ha encontrado a {0}", nombre);
        }

        public void Nomina()
        {
            Console.WriteLine("{0, -20} {1, 10}", "Nombre", "Salario");
            foreach (Empleado empleado in empleados)
            {
                if (empleado is EmpleadoBase) {
                    if (empleado is EmpleadoSindicalizado)
                        Console.WriteLine("{0, -20} {1, 10}", empleado.Nombre, ((EmpleadoSindicalizado) empleado).Salario());
                    else
                        Console.WriteLine("{0, -20} {1, 10}", empleado.Nombre, ((EmpleadoBase) empleado).Salario());
                }
                else
                    Console.WriteLine("{0, -20} {1, 10}", empleado.Nombre, ((EmpleadoJornada) empleado).Salario());
            }
        }
    }
}
