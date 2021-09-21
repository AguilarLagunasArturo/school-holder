using System;

namespace ProyectoPoblacion
{
    class Persona
    {
        // Atributos
        private int edad;
        private char sexo;
        // Encapsular
        public int Edad { get => edad; set => edad = value; }
        public char Sexo { get => sexo; set => sexo = value; }
        // Constructor
        public Persona(int edad, char sexo)
        {
            this.edad = edad;
            this.sexo = sexo;
        }
    }
}
