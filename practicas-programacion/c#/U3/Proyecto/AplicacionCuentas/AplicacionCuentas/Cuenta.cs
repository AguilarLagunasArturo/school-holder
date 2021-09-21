using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionCuentas
{
    class Cuenta
    {
        protected Cliente cliente;
        protected string numero;
        protected List<Operacion> operaciones;
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public string Numero { get => numero; set => numero = value; }
        public Cuenta(string numero, Cliente cliente)
        {
            this.numero = numero;
            this.cliente = cliente;
            operaciones = new List<Operacion>();
        }
        public void Estado()
        {
            Console.WriteLine("\nDatos de la cuenta {0}\n", this.GetType().Name);
            Console.WriteLine("Numero de cuenta: {0}", numero);
            Console.WriteLine("Nombre del cliente: {0}", cliente.Nombre);
            Console.WriteLine("Domicilio:");
            Console.WriteLine("\tLocalidad: {0}", cliente.Domicilio.Localidad);
            Console.WriteLine("\tColonia: {0}", cliente.Domicilio.Colonia);
            Console.WriteLine("\tCalle: {0}", cliente.Domicilio.Calle);
            Console.WriteLine("\tNumero: {0}", cliente.Domicilio.Numero);
            Console.WriteLine("\tCodigo Postal: {0}", cliente.Domicilio.CodigoPostal);

            Console.WriteLine("\nOperaciones Realizadas: {0}\n", operaciones.Count);
            foreach (Operacion operacion in operaciones)
            {
                if (operacion is PagoServicio)
                    Console.WriteLine(
                        "Servicio: {0, -15} ${1, 10:0.00}\t{2, -20}", ((PagoServicio) operacion).Servicio, operacion.Cantidad, operacion.Fecha.ToShortDateString()
                        );
                else
                    Console.WriteLine("{0, -25} ${1, 10:0.00}\t{2, -20}", operacion.GetType().Name, operacion.Cantidad, operacion.Fecha.ToShortDateString());
            }
        }
    }
}
