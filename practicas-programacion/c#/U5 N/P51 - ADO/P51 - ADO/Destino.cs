using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P51___ADO
{
    public class Destino
    {
        private string nombre;
        private double precio;

        public string Nombre { get => nombre; set => nombre = value; }
        public double Precio { get => precio; set => precio = value; }

        public Destino(string nombre, double precio)
        {
            this.nombre = nombre;
            this.precio = precio;
        }
    }
}
