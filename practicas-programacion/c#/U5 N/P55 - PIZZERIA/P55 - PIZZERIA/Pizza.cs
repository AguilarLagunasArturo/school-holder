using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P55___PIZZERIA
{
    public abstract class Pizza
    {
        protected string descripcion;
        protected string estado;

        public string Descripcion { get => descripcion; set => descripcion = value; }

        public Pizza(string estado, string descripcion)
        {
            this.descripcion = descripcion;
            this.estado = estado;
        }

        public abstract double Precio();
    }
}
