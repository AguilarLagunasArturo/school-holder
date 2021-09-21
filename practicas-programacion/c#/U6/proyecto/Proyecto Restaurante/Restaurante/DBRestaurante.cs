using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    class DBRestaurante
    {
        static SqlConnection conexion;
        // ESTABLECE LA CONEXION A LA DB
        public static void DBConectar()
        {
            conexion = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Restaurante;Integrated Security=True");
            conexion.Open();
        }
        
        // ADMINISTRACION DE PRODUCTOS
        public static int AgregarP(Producto producto) // AGREGAR PRODUCTO
        {
            int filasAfectadas = 0;
            string consulta = string.Format("insert into productos (Nombre, Precio) values ('{0}', {1})", producto.Nombre, producto.Precio);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }
        public static int ModificarP(Producto producto) // MODIFICAR PRODUCTO
        {
            int filasAfectadas = 0;
            string consulta = string.Format("UPDATE productos SET Nombre = '{0}', Precio = {1} WHERE Id = {2}",  producto.Nombre, producto.Precio, producto.Id);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }
        public static int EliminarP(Producto producto) // ELIMINAR PRODUCTO
        {
            int filasAfectadas = 0;
            string consulta = string.Format("DELETE FROM Productos WHERE Id = {0}", producto.Id);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }
        public static List<Producto> BuscarP(string nombreBuscar) // BUSCAR PRODUCTO
        {
            List<Producto> listaProductos = new List<Producto>();
            string consulta = string.Format("select * from productos where nombre like '%{0}%'", nombreBuscar); // BUSCA EL NOMBRE DEL PRODUCTO
            // DEVUELVE LOS PRODUCTOS QUE CONTENGAN LA PALABRA AGUA
            /*
            agua de limon
            agua de horchata
            agua

            busco: %agua%

            resultado: 
                agua de limon
                agua de horchata
                agua

            busco: agua
                agua
             
             */
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Producto producto = new Producto(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2));
                listaProductos.Add(producto);
            }
            reader.Close();
            return listaProductos;
        }

        // ADMINISTRACION DE EMPLEADOS
        public static int AgregarE(Empleado empleado)
        {
            int filasAfectadas = 0;
            string consulta = string.Format("insert into empleados (Nombre, Sueldo, Usuario, Password, EsAdmin) " +
                "values ('{0}', {1}, '{2}', '{3}', {4})", empleado.Nombre, empleado.Sueldo, empleado.Usuario, empleado.Password, empleado.EsAdmin);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }
        public static int ModificarE(Empleado empleado)
        {
            int filasAfectadas = 0;
            string mod = string.Format(
                "UPDATE empleados SET Nombre = '{0}', Sueldo = {1}, Usuario = '{2}', Password = '{3}', EsAdmin = {4} WHERE Id = {5}",
                empleado.Nombre, empleado.Sueldo, empleado.Usuario, empleado.Password, empleado.EsAdmin, empleado.Id);
            SqlCommand comando = new SqlCommand(mod, conexion);
            filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }
        public static int EliminarE(Empleado empleado)
        {
            int filasAfectadas = 0;
            string del = string.Format("DELETE FROM Empleados WHERE Id = {0}", empleado.Id);
            SqlCommand comando = new SqlCommand(del, conexion);
            filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }
        public static List<Empleado> BuscarE(string nombreBuscar)
        {
            List<Empleado> listaEmpleados = new List<Empleado>();
            string consulta = string.Format("select * from empleados where nombre like '%{0}%'", nombreBuscar);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Empleado empleado = new Empleado(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
                listaEmpleados.Add(empleado);
            }
            reader.Close();
            return listaEmpleados;
        }

        // ESTA BUSQUEDA SOLO SE UTILIZA PARA EL LOGIN
        public static List<Empleado> BuscarUsuario(string nombreBuscar)
        {
            List<Empleado> listaEmpleados = new List<Empleado>();
            string consulta = string.Format("select * from empleados where usuario = '{0}'", nombreBuscar);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Empleado empleado = new Empleado(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
                listaEmpleados.Add(empleado);
            }
            reader.Close();
            return listaEmpleados;
        }

        // ADMINISTRACION DE FACTURAS
        public static int AgregarF(Factura factura)
        {
            int filasAfectadas = 0;
            string consulta = string.Format("insert into facturas (Cliente, Empleado, Total, Pago, Cambio, Info) " +
                "values ('{0}', '{1}', {2}, {3}, {4}, '{5}')", factura.Cliente, factura.Empleado, factura.Total, factura.Pago, factura.Cambio, factura.Info);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }
        public static List<Factura> BuscarF(string nombreBuscar)
        {
            List<Factura> listaFacturas = new List<Factura>();
            string consulta = "select * from facturas";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            
            while (reader.Read())
            {
                Factura factura = new Factura(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3),
                    reader.GetDouble(4), reader.GetDouble(5), reader.GetString(6));
                listaFacturas.Add(factura);
            }
            reader.Close();
            return listaFacturas;
        }
    }
}
