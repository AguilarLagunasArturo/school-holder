using System;
using System.Linq;

namespace ProyectoPoblacion
{
    class Poblacion
    {
        // Atributos
        private Persona[] personas;
        // Encapsular
        internal Persona[] Personas { get => personas; set => personas = value; }
        // Constructor
        public Poblacion(int numeroPersonas = 3)
        {
            personas = new Persona[numeroPersonas];
        }
        // Funciones
        public void CapturaPersonas()
        {
            Console.WriteLine("CAPTURANDO POBLACION\n");
            for (int i = 0; i < personas.Length; i++)
            {
                Console.WriteLine("Persona {0}", i + 1);
                Console.Write("Edad: ");
                int edad = Convert.ToInt32(Console.ReadLine());
                Console.Write("Sexo (f/m): ");
                char sexo = Console.ReadLine().ElementAt(0);
                personas[i] = new Persona(edad, sexo);
                Console.WriteLine();
            }
        }

        public double PorcentajeMenoresEdad()
        {
            int contador = 0;
            for (int i = 0; i < personas.Length; i++)
            {
                if (personas[i].Edad < 18) { contador++; }
            }
            return (double) contador / personas.Length * 100.0;
        }
        public double PorcentajeMujeres()
        {
            int contador = 0;
            for (int i = 0; i < personas.Length; i++)
            {
                if (personas[i].Sexo.Equals('f')) { contador++; }
            }
            return (double)contador / personas.Length * 100.0;
        }
        public double PorcentajeMujeresMenoresEdad()
        {
            int contador = 0;
            int contador_mujeres = 0;
            for (int i = 0; i < personas.Length; i++)
            {
                if (personas[i].Sexo.Equals('f')) { contador_mujeres++; }
                if (personas[i].Edad < 18 && personas[i].Sexo.Equals('f')) { contador++; }
            }
            return (double)contador / contador_mujeres * 100.0;
        }
    }
}
