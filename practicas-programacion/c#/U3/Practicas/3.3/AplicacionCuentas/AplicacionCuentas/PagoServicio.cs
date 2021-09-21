using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionCuentas
{
    class PagoServicio : Operacion
    {
        protected string servicio;
        public string Servicio { get => servicio; set => servicio = value; }
        public PagoServicio(DateTime fecha, double cantidad, string servicio) : base(fecha, cantidad)
        {
            this.servicio = servicio;
        }
    }
}
