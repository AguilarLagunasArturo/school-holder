using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionCuentas
{
    class Cliente
    {
        private string nombre;
        private string domicilio;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }

        public Cliente(string nombre, string domicilio)
        {
            this.nombre = nombre;
            this.domicilio = domicilio;
        }
    }
}
