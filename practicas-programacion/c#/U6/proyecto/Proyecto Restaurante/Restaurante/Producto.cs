using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    public class Producto
    {
        private int id;
        private string nombre;
        private double precio;

        public string Nombre { get => nombre; set => nombre = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Id { get => id; set => id = value; }

        // SE UTILIZA PARA CREAR PRODUCTOS MEDIANTE BUSQUEDAS A LA BASE DE DATOS Y MOSTRARLO EN LA DATAGRID
        public Producto(int id, string nombre, double precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
        }

        // SE UTILIZA AL AGREGAR PRODUCTOS PORQUE AUN NO SE SABE EL ID
        public Producto(string nombre, double precio)
        {
            this.nombre = nombre;
            this.precio = precio;
        }
    }
}
