using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionCompra
{
    class Producto
    {
        // Atributos
        private string descripcion;

        public string Descripcion { get => descripcion; set => descripcion = value; }
        
        private double precio;
        public double Precio { get => precio; set => precio = value; }

        // Constructor
        public Producto(string descripcion, double precio)
        {
            this.descripcion = descripcion;
            this.precio = precio;
        }
    }
}
