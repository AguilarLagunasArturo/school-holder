using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionCuentas
{
    class Deposito: Operacion
    {
        public Deposito(DateTime fecha, double cantidad) : base(fecha, cantidad) { }
    }
}
