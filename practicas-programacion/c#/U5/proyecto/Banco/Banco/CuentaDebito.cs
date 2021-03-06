using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco
{
    public class CuentaDebito: Cuenta
    {

        public CuentaDebito(string numero, Cliente cliente, string nip) : base(numero, cliente, nip)
        {
            saldo = 0.0;
            tipo = "Debito";
        }

        public CuentaDebito(string numero, Cliente cliente, string nip, double saldo) : base(numero, cliente, nip)
        {
            this.saldo = saldo;
            tipo = "Debito";
        }

        public override double Depositar(double cantidad)
        {
            if (cantidad > 0.0) {
                saldo += cantidad;
                Operaciones.Add(new Deposito(DateTime.Now, cantidad));
            }
            else if (cantidad < 0.0)
            {
                saldo += cantidad;
                Operaciones.Add(new Deposito(DateTime.Now, -cantidad));
            }
            else
                cantidad = 0.0;
            return cantidad;
        }
        public override double Retirar(double cantidad)
        {
            if (cantidad <= saldo)
            {
                saldo -= cantidad;
                Operaciones.Add(new Retiro(DateTime.Now, cantidad));
            }  
            else
                cantidad = 0.0;
            return cantidad;
        }
        public override double PagoServicio(double cantidad, string servicio)
        {
            if (cantidad <= saldo)
            {
                saldo -= cantidad;
                Operaciones.Add(new PagoServicio(DateTime.Now, cantidad, servicio));
            }
            else
                cantidad = 0.0;
            return cantidad;
        }
        public override void Estado()
        {
            Console.WriteLine("\nDatos de la cuenta de credito\n");
            Console.WriteLine("Numero de cuenta: {0}", numero);
            Console.WriteLine("Nombre del cliente: {0}", cliente.Nombre);
            Console.WriteLine("Saldo actual: ${0}", saldo);

            Console.WriteLine("Domicilio:");
            Console.WriteLine("\tLocalidad: {0}", cliente.Domicilio.Localidad);
            Console.WriteLine("\tColonia: {0}", cliente.Domicilio.Colonia);
            Console.WriteLine("\tCalle: {0}", cliente.Domicilio.Calle);
            Console.WriteLine("\tNumero: {0}", cliente.Domicilio.Numero);
            Console.WriteLine("\tCodigo Postal: {0}", cliente.Domicilio.CodigoPostal);

            Console.WriteLine("\nOperaciones Realizadas: {0}\n", Operaciones.Count);
            foreach (Operacion operacion in Operaciones)
            {
                if (operacion is PagoServicio)
                    Console.WriteLine(
                        "Servicio: {0, -15} ${1, 10:0.00}\t{2, -20}", ((PagoServicio)operacion).Servicio, operacion.Cantidad, operacion.Fecha.ToShortDateString()
                        );
                else
                    Console.WriteLine("{0, -25} ${1, 10:0.00}\t{2, -20}", operacion.GetType().Name, operacion.Cantidad, operacion.Fecha.ToShortDateString());
            }
        }
    }
}
