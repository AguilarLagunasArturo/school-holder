using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoServicios
{
    public class Paquete
    {
        string descripcion;

        double precio;

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Precio { get => precio; set => precio = value; }

        public Paquete(string descripcion, double precio)
        {
            this.Descripcion = descripcion;
            this.Precio = precio;
        }

        public override string ToString()
        {
            return descripcion;
        }

    }
}
