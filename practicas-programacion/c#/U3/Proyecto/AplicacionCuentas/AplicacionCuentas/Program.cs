using System;
using System.Collections.Generic;
using System.Linq;

namespace AplicacionCuentas
{
    class Program
    {
        // Variables globales
        public static List<CuentaDebito> cuentas = new List<CuentaDebito>();
        // Funciones
        public static Cliente GenerarCliente()
        {
            string nombre, calle, cPostal, colonia, localidad, numero;
            Console.Write("Nombre del cliente: ");
            nombre = Console.ReadLine();
            Console.Write("Calle: ");
            calle = Console.ReadLine();
            Console.Write("Codigo postal: ");
            cPostal = Console.ReadLine();
            Console.Write("Colonia: ");
            colonia = Console.ReadLine();
            Console.Write("Localidad: ");
            localidad = Console.ReadLine();
            Console.Write("Numero: ");
            numero = Console.ReadLine();
            return new Cliente(nombre, calle, cPostal, colonia, localidad, numero);
        }
        public static void AgregarCuenta()
        {
            char opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Submenu para Crear Cuenta\n");
                Console.WriteLine("[1] Crear cuenta de debito");
                Console.WriteLine("[2] Crear cuenta de credito");
                Console.WriteLine("[0] Regresar al menu anterior\n");

                Console.Write("Elige una opccion: ");
                opcion = Console.ReadLine().ElementAt(0);
                Console.WriteLine();

                switch (opcion)
                {
                    case '1':
                        cuentas.Add(new CuentaDebito("d" + Convert.ToString(cuentas.Count), GenerarCliente()));
                        Console.WriteLine("\nSe ha creado la cuenta de debito, su numero de cuenta es: {0}", cuentas[cuentas.Count - 1].Numero);
                        opcion = '0';
                        break;
                    case '2':
                        Console.Write("Ingrese el credito que desea solicitar: ");
                        double limiteCredito = Convert.ToDouble(Console.ReadLine());
                        cuentas.Add(new CuentaCredito("c" + Convert.ToString(cuentas.Count), GenerarCliente(), limiteCredito));
                        Console.WriteLine("\nSe ha creado la cuenta de credito, su numero de cuenta es: {0}", cuentas[cuentas.Count - 1].Numero);
                        opcion = '0';
                        break;
                    case '0':
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta, vuelve a intentarlo");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != '0');
        }

        public static void EliminarCuenta()
        {
            Console.Write("Numero de cuenta: ");
            string numero = Console.ReadLine();
            bool eliminado = false;
            foreach (CuentaDebito cuenta in cuentas)
            {
                if (cuenta.Numero.Equals(numero))
                {
                    cuentas.Remove(cuenta);
                    eliminado = true;
                    break;
                }
            }
            if (eliminado)
                Console.WriteLine("Se ha eliminado la cuenta: {0}", numero);
            else
                Console.WriteLine("No existe una cuenta con el numero: {0}", numero);
        }

        public static void SolicitarDeposito()
        {
            Console.Write("Ingresar numero de cuenta: ");
            string numero = Console.ReadLine();
            double monto;
            do
            {
                Console.Write("Ingresar monto a depositar: ");
                monto = Convert.ToDouble(Console.ReadLine());
                if (monto <= 0)
                    Console.WriteLine("El monto debe ser un numero positivo.");
            } while (monto <= 0);
            bool encontrado = false;
            for (int i = 0; i < cuentas.Count; i++)
            {
                if (cuentas[i].Numero.Equals(numero))
                {
                    if (cuentas[i] is CuentaCredito)
                    {
                        Console.WriteLine("No se puede depositar en una cuenta de credito.");
                        return;
                    }
                    cuentas[i].Depositar(monto);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("El numero de cuenta no existe: '{0}'", numero);
            }
            else
            {
                Console.WriteLine("Monto depositado: ${0}", monto);
            }
        }

        public static void SolicitarRetiro()
        {
            Console.Write("Ingresar numero de cuenta: ");
            string numero = Console.ReadLine();
            double monto;
            do
            {
                Console.Write("Ingresar monto a retirar: ");
                monto = Convert.ToDouble(Console.ReadLine());
                if (monto <= 0)
                    Console.WriteLine("El monto debe ser un numero positivo.");
            } while (monto <= 0);
            bool encontrado = false;
            for (int i = 0; i < cuentas.Count; i++)
            {
                if (cuentas[i].Numero.Equals(numero))
                {
                    monto = cuentas[i].Retirar(monto);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("No existe el numero de cuenta: '{0}'", numero);
                return;
            }
            else
            {
                Console.WriteLine("Monto retirado: ${0}", monto);
            }
        }

        public static void PagoDeServicios()
        {
            Console.Write("Ingresar numero de cuenta: ");
            string numero = Console.ReadLine();
            Console.Write("Nombre del servicio: ");
            string servicio = Console.ReadLine();
            double monto;
            do
            {
                Console.Write("Ingresar monto a pagar: ");
                monto = Convert.ToDouble(Console.ReadLine());
                if (monto <= 0)
                    Console.WriteLine("El monto debe ser un numero positivo.");
            } while (monto <= 0);
            bool encontrado = false;
            for (int i = 0; i < cuentas.Count; i++)
            {
                if (cuentas[i].Numero.Equals(numero))
                {
                    monto = cuentas[i].PagoServicio(monto, servicio);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("No existe el numero de cuenta: '{0}'", numero);
                return;
            }
            else
            {
                Console.WriteLine("Monto pagado: ${0}", monto);
            }
        }

        public static void ConsultarSaldo()
        {
            Console.Write("Ingresar numero de cuenta: ");
            string numero = Console.ReadLine();
            bool encontrado = false;
            CuentaDebito cuentaEncontrada = null;
            foreach (CuentaDebito cuenta in cuentas)
            {
                if (cuenta.Numero.Equals(numero))
                {
                    cuentaEncontrada = cuenta;
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("No existe el numero de cuenta: '{0}'", numero);
                return;
            }
            else
            {
                Console.WriteLine("El saldo de la cuenta {0} es: ${1}", cuentaEncontrada.Numero, cuentaEncontrada.Saldo);
            }
        }

        public static void ConsultarEstado()
        {
            Console.Write("Ingresar numero de cuenta: ");
            string numero = Console.ReadLine();
            bool encontrado = false;
            CuentaDebito cuentaEncontrada = null;
            foreach (CuentaDebito cuenta in cuentas)
            {
                if (cuenta.Numero.Equals(numero))
                {
                    cuentaEncontrada = cuenta;
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("No existe el numero de cuenta: '{0}'", numero);
                return;
            }
            else
            {
                cuentaEncontrada.Estado();
            }
        }

        public static void ModificarCuenta()
        {
            Console.Write("Ingresar numero de cuenta: ");
            string numero = Console.ReadLine();
            bool encontrado = false;
            CuentaDebito cuentaEncontrada = null;
            for (int i = 0; i < cuentas.Count; i++)
            {
                if (cuentas[i].Numero.Equals(numero))
                {
                    encontrado = true;

                    Console.WriteLine("Ingrese la nueva direccion del cliente");
                    Console.Write("Calle: ");
                    cuentas[i].Cliente.Domicilio.Calle = Console.ReadLine();
                    Console.Write("Codigo postal: ");
                    cuentas[i].Cliente.Domicilio.CodigoPostal = Console.ReadLine();
                    Console.Write("Colonia: ");
                    cuentas[i].Cliente.Domicilio.Colonia = Console.ReadLine();
                    Console.Write("Localidad: ");
                    cuentas[i].Cliente.Domicilio.Localidad = Console.ReadLine();
                    Console.Write("Numero: ");
                    cuentas[i].Cliente.Domicilio.Numero = Console.ReadLine();

                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("No existe el numero de cuenta: '{0}'", numero);
                return;
            }
            else
            {
                Console.WriteLine("Se han guardado los cambios para {0}", numero);
            }
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            /*
            	Agregar una Cuenta [X]
                o	Debito [X]
                o	Crédito [X]
            	Eliminar una Cuenta [X]
            	Realización de Operaciones.
                o	Depósitos [X]
                o	Retiros [X]
                o	“Operación”  (propuesta en la practica 3.3) [X]
                o	Consulta
                    	Saldo [X]
                    	Estado (saldo, operaciones realizadas, …) [X]
            	Modificar [X]
            */
            char opcion;
            do
            {
                Console.Clear();

                Console.WriteLine("Menu de opcciones:\n");
                Console.WriteLine("[1] Agregar una Cuenta");
                Console.WriteLine("[2] Eliminar una Cuenta");
                Console.WriteLine("[3] Depositar");
                Console.WriteLine("[4] Retirar");
                Console.WriteLine("[5] Pagar servicio");
                Console.WriteLine("[6] Consultar saldo");
                Console.WriteLine("[7] Consultar estado de cuenta");
                Console.WriteLine("[8] Modificar una cuenta");
                Console.WriteLine("[0] Salir");

                Console.Write("\nElije una opcion: ");
                opcion = Console.ReadLine().ElementAt(0);
                Console.WriteLine();

                switch (opcion)
                {
                    case '1':
                        AgregarCuenta();
                        Console.ReadKey();
                        break;
                    case '2':
                        EliminarCuenta();
                        Console.ReadKey();
                        break;
                    case '3':
                        SolicitarDeposito();
                        Console.ReadKey();
                        break;
                    case '4':
                        SolicitarRetiro();
                        Console.ReadKey();
                        break;
                    case '5':
                        PagoDeServicios();
                        Console.ReadKey();
                        break;
                    case '6':
                        ConsultarSaldo();
                        Console.ReadKey();
                        break;
                    case '7':
                        ConsultarEstado();
                        Console.ReadKey();
                        break;
                    case '8':
                        ModificarCuenta();
                        Console.ReadKey();
                        break;
                    case '0':
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta, vuelve a intentarlo");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != '0');
        }
    }
}
