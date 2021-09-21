using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    public class Producto
    {
        private string nombre;
        private string descripcion;
        private double precio;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Precio { get => precio; set => precio = value; }
        public Producto(string nombre, string descripcion, double precio)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
        }

        public string Info()
        {
            string info = "Nombre: ";
            info += nombre;
            info += "\n\tPrecio: $";
            info += precio.ToString();
            info += "\n\tDescripcion: ";
            info += descripcion;
            return info;
        }
    }
}
