using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionCuentas
{
    class CuentaCredito: CuentaDebito
    {
        protected double limiteCredito;

        public double LimiteCredito { get => limiteCredito; set => limiteCredito = value; }

        public CuentaCredito(string numero, Cliente cliente, double limiteCredito) : base(numero, cliente)
        {
            this.limiteCredito = limiteCredito;
            saldo = limiteCredito;
        }

        public new void Estado()
        {
            base.Estado();
            Console.WriteLine("Limite de credito: ${0}", limiteCredito);
        }
    }
}