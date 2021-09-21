using System;

namespace AplicacionCuentas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Cliente cliente1 = new Cliente("Perez Ramirez", "Conocido #123");

            CuentaDebito cDebito = new CuentaDebito("d12345", cliente1);
            cDebito.Depositar(1000.0);
            cDebito.Retirar(500.0);
            cDebito.Estado();

            // ACTIVIDAD COMPLEMENTARIA DE WORD: CUENTA CREDITO
            CuentaCredito cCredito = new CuentaCredito("c12345", cliente1, 5000.0);
            cCredito.Retirar(2000.0);
            cCredito.Estado();

            Console.ReadKey();
        }
    }
}
