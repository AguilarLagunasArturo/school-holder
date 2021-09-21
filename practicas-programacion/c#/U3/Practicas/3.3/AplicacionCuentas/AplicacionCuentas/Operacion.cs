using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionCuentas
{
    class Operacion
    {
        protected double cantidad;
        protected DateTime fecha;
        public double Cantidad { get => cantidad; set => cantidad = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Operacion(DateTime fecha, double cantidad)
        {
            this.cantidad = cantidad;
            this.fecha = fecha;
        }
    }
}
