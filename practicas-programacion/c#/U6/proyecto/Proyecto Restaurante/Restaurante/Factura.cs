using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    class Factura
    {
        private int id;
        private string cliente;
        private string empleado;
        private double total;
        private double pago;
        private double cambio;
        private string info;

        public string Cliente { get => cliente; set => cliente = value; }
        public double Pago { get => pago; set => pago = value; }
        public double Cambio { get => cambio; set => cambio = value; }
        public string Info { get => info; set => info = value; }
        public int Id { get => id; set => id = value; }
        public string Empleado { get => empleado; set => empleado = value; }
        public double Total { get => total; set => total = value; }


        
        // SE UTILIZA AL AGREGAR PRODUCTOS PORQUE AUN NO SE SABE EL ID
        public Factura(string cliente, string empleado, double total, double pago, double cambio, string info)
        {
            this.cliente = cliente;
            this.empleado = empleado;
            this.pago = pago;
            this.total = total;
            this.cambio = cambio;
            this.info = info;
        }


        // SE UTILIZA AL BUSCAR FACTURAS Y MOESTRARLAS EN EL DATAGRID
        public Factura(int id, string cliente, string empleado, double total, double pago, double cambio, string info)
        {
            this.id = id;
            this.cliente = cliente;
            this.empleado = empleado;
            this.pago = pago;
            this.total = total;
            this.cambio = cambio;
            this.info = info;
        }
    }
}
