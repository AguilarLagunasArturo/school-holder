using System;
using System.Collections.Generic;
using System.Text;

namespace Banco
{
    public class Operacion
    {
        protected double cantidad;
        protected DateTime fecha;
        protected string descripcion;
        protected string tipo;
        public double Cantidad { get => cantidad; set => cantidad = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        public Operacion(DateTime fecha, double cantidad)
        {
            this.cantidad = cantidad;
            this.fecha = fecha;
        }
    }
}
