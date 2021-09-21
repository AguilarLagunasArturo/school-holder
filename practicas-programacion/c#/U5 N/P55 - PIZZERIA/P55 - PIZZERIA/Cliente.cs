using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P55___PIZZERIA
{
    public class Cliente
    {
        protected string nombre;
        protected string telefono;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public Cliente(string nombre, string telefono)
        {
            this.nombre = nombre;
            this.telefono = telefono;
        }
    }
}
