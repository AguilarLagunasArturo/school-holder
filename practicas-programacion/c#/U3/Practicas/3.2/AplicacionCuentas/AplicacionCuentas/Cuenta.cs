using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionCuentas
{
    class Cuenta
    {
        protected Cliente cliente;
        protected string numero;

        public Cliente Cliente { get => cliente; set => cliente = value; }
        public string Numero { get => numero; set => numero = value; }

        public Cuenta(string numero, Cliente cliente)
        {
            this.numero = numero;
            this.cliente = cliente;
        }

        public void Estado()
        {
            if (this is CuentaCredito)
            {
                Console.WriteLine("\nDatos de cuenta de credito.\n");
            }
            else
            {
                Console.WriteLine("\nDatos de cuenta de debito.\n");
            }
            // no. nombre cliente domicilio
            Console.WriteLine("Numero de cuenta: {0}", numero);
            Console.WriteLine("Nombre del cliente: {0}", cliente.Nombre);
            Console.WriteLine("Domicilio: {0}", cliente.Domicilio);
        }
    }
}
