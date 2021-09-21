using System;

namespace AplicacionCompra
{
    class Program
    {
        static void Main(string[] args)
        {
            Compra compra = new Compra("Perez Ramirez Jose Luis", "PERJ400602", "Estufa Samsung", 6000.0);
            compra.Factura();
            Console.ReadKey();
        }
    }
}