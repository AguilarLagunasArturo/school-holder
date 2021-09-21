using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionCuentas
{
    class Retiro : Operacion
    {
        public Retiro(DateTime fecha, double cantidad) : base(fecha, cantidad) { }
    }
}
