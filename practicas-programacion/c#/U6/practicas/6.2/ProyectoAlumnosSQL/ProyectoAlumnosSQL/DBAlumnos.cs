using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAlumnosSQL
{
    public class DBAlumnos
    {
        static SqlConnection conexion;
        public static void DBConectar()
        {
            conexion = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Escuela;Integrated Security=True");
            conexion.Open();
        }
        public static int Agregar(Alumno alumno)
        {
            int filasAfectadas = 0;
            string consulta = string.Format("insert into alumnos (Nombre, Materia, Calificacion) " +
                "values ('{0}', '{1}', {2})", alumno.Nombre, alumno.Materia, alumno.Calificacion);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }
        public static int Modificar(Alumno alumno)
        {
            int filasAfectadas = 0;
            string mod = string.Format("UPDATE Alumnos SET Nombre = '{0}', Materia = '{1}', Calificacion = {2} WHERE Id = {3}", alumno.Nombre, alumno.Materia, alumno.Calificacion, alumno.Id);
            SqlCommand comando = new SqlCommand(mod, conexion);
            filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }
        public static int Eliminar(Alumno alumno)
        {
            int filasAfectadas = 0;
            string del = string.Format("DELETE FROM Alumnos WHERE Id = {0}", alumno.Id);
            SqlCommand comando = new SqlCommand(del, conexion);
            filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }

        public static List<Alumno> BuscarAlumno(string nombre)
        {
            List<Alumno> listaAlumnos = new List<Alumno>();
            string consulta = string.Format("select * from alumnos where nombre = '{0}' order by nombre asc", nombre);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Alumno alumno = new Alumno(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                listaAlumnos.Add(alumno);
            }

            reader.Close();
            return listaAlumnos;
        }

        public static List<Alumno> Buscar(string nombreBuscar)
        {
            List<Alumno> listaAlumnos = new List<Alumno>();
            string consulta = string.Format("select * from alumnos where nombre like '%{0}%'", nombreBuscar);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Alumno alumno = new Alumno(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                listaAlumnos.Add(alumno);
            }
            reader.Close();
            return listaAlumnos;
        }

    }
}
