using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P55___PIZZERIA
{
    public class Pedido
    {
        protected Cliente cliente;
        protected int numeroDeIngredientesAdicionales;
        protected Pizza pizza;
        protected double precioPorIngrediente;
        protected string estado;
        private string totalString;
        private string nombreCliente;
        private string telefonoCliente;
        private string descripcionPizza;

        public int NumeroDeIngredientesAdicionales { get => numeroDeIngredientesAdicionales; set => numeroDeIngredientesAdicionales = value; }
        public double PrecioPorIngrediente { get => precioPorIngrediente; set => precioPorIngrediente = value; }
        internal Cliente Cliente { get => cliente; set => cliente = value; }
        internal Pizza Pizza { get => pizza; set => pizza = value; }
        public string Estado { get => estado; set => estado = value; }
        public string TotalString { get => totalString; set => totalString = value; }
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string TelefonoCliente { get => telefonoCliente; set => telefonoCliente = value; }
        public string DescripcionPizza { get => descripcionPizza; set => descripcionPizza = value; }

        public Pedido(Cliente cliente, int numeroDeIngredientesAdicionales, Pizza pizza, double precioPorIngrediente, string estado)
        {
            this.cliente = cliente;
            this.numeroDeIngredientesAdicionales = numeroDeIngredientesAdicionales;
            this.pizza = pizza;
            this.precioPorIngrediente = precioPorIngrediente;
            this.estado = estado;
            this.totalString = Total().ToString();
            this.NombreCliente = cliente.Nombre;
            this.TelefonoCliente = cliente.Telefono;
            this.descripcionPizza = pizza.Descripcion;
        }

        public double Total()
        {
            return pizza.Precio() + (double)numeroDeIngredientesAdicionales * precioPorIngrediente;
        }

        public string GeneraFactura()
        {
            string factura = "* * * * FACTURA * * * * \n";
            factura += "\nCliente:\t\t" + Cliente.Nombre;
            factura += "\nTelefono:\t" + Cliente.Telefono;
            factura += "\nDescripcion:\t" + Pizza.Descripcion;
            factura += "\nTotal:\t\t$" + Total().ToString();

            return factura;
        }
    }
}
