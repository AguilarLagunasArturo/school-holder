using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionCompra
{
    class Cliente
    {
        // Atributos
        private string nombre;
        public string Nombre { get => nombre; set => nombre = value; }

        private string rfc;
        public string Rfc { get => rfc; set => rfc = value; }

        // Constructor
        public Cliente(string nombre, string rfc)
        {
            this.nombre = nombre;
            this.rfc = rfc;
        }
    }
}
