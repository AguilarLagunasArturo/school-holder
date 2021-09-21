using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionCuentas
{
    class Cliente
    {
        private string nombre;
        private Domicilio domicilio;

        public string Nombre { get => nombre; set => nombre = value; }
        internal Domicilio Domicilio { get => domicilio; set => domicilio = value; }

        public Cliente(string nombre, string calle, string codigoPostal, string colonia, string localidad, string numero)
        {
            this.nombre = nombre;
            this.domicilio = new Domicilio(calle, codigoPostal, colonia, localidad, numero);
        }
    }
}
