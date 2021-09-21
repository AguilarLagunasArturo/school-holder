using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAlumnosSQL
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Materia { get; set; }
        public int Calificacion { get; set; }

        public Alumno(int id, string nombre, string materia, int calificacion)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Materia = materia;
            this.Calificacion = calificacion;
        }

        public Alumno() { }

    }
}
