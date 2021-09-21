using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P52___COTIZACION
{
    public class Automovil
    {
        private string modelo;
        private double precioBase;

        public string Modelo { get => modelo; set => modelo = value; }
        public double PrecioBase { get => precioBase; set => precioBase = value; }

        public Automovil(string modelo, double precioBase)
        {
            this.modelo = modelo;
            this.precioBase = precioBase;
        }
    }
}
