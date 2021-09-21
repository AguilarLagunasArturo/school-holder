using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoServicios
{
    public class Cliente
    {
        string nombre;

        string direccion;

        Paquete paquete;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public Paquete Paquete { get => paquete; set => paquete = value; }

        public Cliente(string nombre, string direccion, Paquete paquete)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Paquete = paquete;
        }

    }
}
