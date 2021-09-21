using System;
using System.Collections.Generic;
using System.Text;

namespace Banco
{
    public class Deposito: Operacion
    {
        public Deposito(DateTime fecha, double cantidad) : base(fecha, cantidad)
        {
            tipo = "Deposito";
            descripcion = "Deposito";
        }
    }
}
