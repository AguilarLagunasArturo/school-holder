using System;

namespace ProyectoPoblacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Poblacion poblacion = new Poblacion(3);
            poblacion.CapturaPersonas();
            Console.WriteLine("Porcentaje menores de edad: {0}%", poblacion.PorcentajeMenoresEdad());
            Console.WriteLine("Porcentaje de mujeres: {0}%", poblacion.PorcentajeMujeres());
            Console.WriteLine("Porcentaje de mujeres menores de edad: {0}%", poblacion.PorcentajeMujeresMenoresEdad());
            Console.ReadKey();
        }
    }
}