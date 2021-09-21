using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    public class Empleado
    {
        private int id;
        private string nombre;
        private double sueldo;
        private string usuario;
        private string password;
        private int esAdmin;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Sueldo { get => sueldo; set => sueldo = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Password { get => password; set => password = value; }
        public int EsAdmin { get => esAdmin; set => esAdmin = value; }

        // SE UTILIZA PARA CREAR EMPLEADOS MEDIANTE BUSQUEDAS A LA BASE DE DATOS Y MOSTRARLO EN LA DATAGRID
        public Empleado(int id, string nombre, double sueldo, string usuario, string password, int esAdmin)
        {
            this.id = id;
            this.nombre = nombre;
            this.sueldo = sueldo;
            this.usuario = usuario;
            this.password = password;
            this.esAdmin = esAdmin;
        }


        // SE UTILIZA AL AGREGAR EMPLEADOS PORQUE AUN NO SE SABE EL ID
        public Empleado(string nombre, double sueldo, string usuario, string password, int esAdmin)
        {
            this.nombre = nombre;
            this.sueldo = sueldo;
            this.usuario = usuario;
            this.password = password;
            this.esAdmin = esAdmin;
        }
    }
}
