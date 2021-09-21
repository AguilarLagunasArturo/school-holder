using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionCuentas
{
    class Domicilio
    {
        private string calle;
        private string codigoPostal;
        private string colonia;
        private string localidad;
        private string numero;

        public string Calle { get => calle; set => calle = value; }
        public string CodigoPostal { get => codigoPostal; set => codigoPostal = value; }
        public string Colonia { get => colonia; set => colonia = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        public string Numero { get => numero; set => numero = value; }
        
        public Domicilio(string calle, string codigoPostal, string colonia, string localidad, string numero)
        {
            this.calle = calle;
            this.codigoPostal = codigoPostal;
            this.colonia = colonia;
            this.localidad = localidad;
            this.numero = numero;
        }
    }
}
