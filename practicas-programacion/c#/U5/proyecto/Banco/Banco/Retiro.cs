using System;
using System.Collections.Generic;
using System.Text;

namespace Banco
{
    public class Retiro : Operacion
    {
        public Retiro(DateTime fecha, double cantidad) : base(fecha, cantidad) 
        {
            tipo = "Retiro";
            descripcion = "Retiro";
        }
    }
}
