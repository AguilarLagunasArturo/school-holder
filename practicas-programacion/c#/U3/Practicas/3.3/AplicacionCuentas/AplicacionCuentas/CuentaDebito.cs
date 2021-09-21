using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AplicacionCuentas
{
    class CuentaDebito: Cuenta
    {
        protected double saldo;
        public double Saldo { get => saldo; set => saldo = value; }

        public CuentaDebito(string numero, Cliente cliente) : base(numero, cliente) {
            saldo = 0.0;
        }
        public double Depositar(double cantidad)
        {
            if (cantidad > 0.0) {
                saldo += cantidad;
                operaciones.Add(new Deposito(DateTime.Now, cantidad));
            }
            else
                cantidad = 0.0;
            return cantidad;
        }
        public double Retirar(double cantidad)
        {
            if (cantidad <= saldo)
            {
                saldo -= cantidad;
                operaciones.Add(new Retiro(DateTime.Now, cantidad));
            }  
            else
                cantidad = 0.0;
            return cantidad;
        }
        public double PagoServicio(double cantidad, string servicio)
        {
            if (cantidad <= saldo)
            {
                saldo -= cantidad;
                operaciones.Add(new PagoServicio(DateTime.Now, cantidad, servicio));
            }
            else
                cantidad = 0.0;
            return cantidad;
        }
        public new void Estado()
        {
            base.Estado();
            Console.WriteLine("\nSaldo actual: ${0}", saldo);
        }
    }
}
