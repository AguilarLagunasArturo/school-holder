using System;
using System.Collections.Generic;
using System.Text;

namespace Banco
{
    public class CuentaCredito: CuentaDebito
    {
        protected double limiteCredito;

        public double LimiteCredito { get => limiteCredito; set => limiteCredito = value; }

        public CuentaCredito(string numero, Cliente cliente, string nip, double limiteCredito) : base(numero, cliente, nip)
        {
            this.limiteCredito = limiteCredito;
            saldo = limiteCredito;
            tipo = "Credito";
        }

        public override void Estado()
        {
            Console.WriteLine("\nDatos de la cuenta de credito\n");
            Console.WriteLine("Numero de cuenta: {0}", numero);
            Console.WriteLine("Nombre del cliente: {0}", cliente.Nombre);
            Console.WriteLine("Limite de credito: ${0}", limiteCredito);

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