using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    public class Cliente
    {
        private string nombre;
        private double presupuesto;
        private char sexo;
        private List<Producto> productos;
        private string id;

        public string Nombre { get => nombre; set => nombre = value; }
        public double Presupuesto { get => presupuesto; set => presupuesto = value; }
        public char Sexo { get => sexo; set => sexo = value; }
        internal List<Producto> Productos { get => productos; set => productos = value; }
        public string Id { get => id; set => id = value; }

        public Cliente(string nombre, double presupuesto, char sexo)
        {
            this.nombre = nombre;
            this.presupuesto = presupuesto;
            this.sexo = sexo;
            this.productos = new List<Producto>();
            this.id = DateTime.Now.ToString() + "  -  "  + nombre.ToUpper();
        }

        public double Total()
        {
            double total = 0.0;
            foreach (Producto p in productos)
            {
                total += p.Precio;
            }
            return total;
        }

        public string Factura()
        {
            string factura = "----------------------------FACTURA-----------------------------\n\n";
            factura += String.Format("{0, -27} {1, -10} {2, -12} {3, -12}", "Nombre", "Cantidad", "Precio (x1)", "Precio Total\n\n");
            List<Producto> productosUnicos = new List<Producto>();
            foreach (Producto p in productos)
            {
                if (productosUnicos.Contains(p))
                    continue;
                productosUnicos.Add(p);
                factura += String.Format("> {0, -25} {1, -10} $ {2, -10} $ {3, -10}",
                    p.Nombre,
                    productos.Where(producto => producto.Nombre == p.Nombre).Count(),
                    p.Precio,
                    productos.Where(producto => producto.Nombre == p.Nombre).Sum(producto => producto.Precio)
                );
                factura += '\n';
            }

            factura += "\n";
            factura += String.Format("{0, 51} $ {1, -10}", "Total: ", Total());
            factura += "\n";
            factura += String.Format("{0, 51} $ {1, -10}", "Cambio: ", presupuesto - Total());
            if (Total() == 0)
                factura = "";
            return factura;
        }
    }
}
