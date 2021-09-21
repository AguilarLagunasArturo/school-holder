using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionCompra
{
    class Compra
    {
        // Atributos
        private static double iva = 16;
        private Cliente cliente;
        private Producto producto;

        public static double Iva { get => iva; set => iva = value; }
        internal Cliente Cliente { get => cliente; set => cliente = value; }
        internal Producto Producto { get => producto; set => producto = value; }

        // Constructores
        public Compra(Cliente cliente, string descripcion, double precio)
        {
            this.cliente = cliente;
            producto = new Producto(descripcion, precio);
        }

        public Compra(Cliente cliente, Producto producto)
        {
            this.cliente = cliente;
            this.producto = producto;
        }

        public Compra(string nombre, string rfc, string descripcion, double precio)
        {
            cliente = new Cliente(nombre, rfc);
            producto = new Producto(descripcion, precio);
        }

        // Funciones
        public double Total()
        {
            return producto.Precio * (1 + iva / 100.0);
        }
        public void Factura()
        {
            Console.WriteLine("Nombre:\t{0}", cliente.Nombre);
            Console.WriteLine("RFC:\t{0}", cliente.Rfc);
            Console.WriteLine("\n\t\tPRODUCTO:\n");
            Console.WriteLine("{0, -20} {1, 10}", producto.Descripcion, producto.Precio);
            Console.WriteLine("{0, -20} {1, 10}", "Total $", Total());
        }
    }
}
