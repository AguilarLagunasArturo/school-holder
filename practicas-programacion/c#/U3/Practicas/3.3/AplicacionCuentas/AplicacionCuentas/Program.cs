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
            Cliente cliente1 = new Cliente("Perez Ramirez", "Conocido", "91697", "Tejeria", "Veracruz", "32");

            CuentaDebito cDebito = new CuentaDebito("d12345", cliente1);
            cDebito.Depositar(10000.0);
            cDebito.Retirar(500.0);
            cDebito.PagoServicio(1200.0, "Luz");
            cDebito.PagoServicio(800.0, "Agua");
            cDebito.Estado();

            // ACTIVIDAD COMPLEMENTARIA DE WORD: CUENTA CREDITO
            CuentaCredito cCredito = new CuentaCredito("c12345", cliente1, 5000.0);
            cCredito.Retirar(2000.0);
            cCredito.Estado();

            Console.ReadKey();
        }
    }
}
