using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProyectoEstado
{
    class Estado
    {
        private string nombre;
        private List<Municipio> municipios;

        public string Nombre { get => nombre; set => nombre = value; }
        internal List<Municipio> Municipios { get => municipios; set => municipios = value; }

        public Estado(string nombre)
        {
            this.nombre = nombre;
            this.Municipios = new List<Municipio>();
        }

        public int Poblacion()
        {
            int poblacionTotal = 0;
            foreach (Municipio m in municipios){ poblacionTotal += m.Poblacion; }
            return poblacionTotal;
            // return municipios.Sum(delegate (Municipio m) { return m.Poblacion; });
            // return municipios.Sum(mun => mun.Poblacion);
        }

        public void ListaMunicipios()
        {
            Console.WriteLine("Estado {0}:", nombre);
            Console.WriteLine("Numero de municipios {0}:", municipios.Count);
            foreach (Municipio m in municipios) {
                Console.WriteLine("{0, -20} {1, 10}", m.Nombre, m.Poblacion);
            }
        }
        public void ListaMunicipiosZonaGeografica()
        {
            List<Municipio> zonaN = new List<Municipio>();
            List<Municipio> zonaC = new List<Municipio>();
            List<Municipio> zonaS = new List<Municipio>();
            foreach (Municipio m in municipios) {
                if (m.ZonaGeografica == 'N')
                    zonaN.Add(m);
                if (m.ZonaGeografica == 'C')
                    zonaC.Add(m);
                if (m.ZonaGeografica == 'S')
                    zonaS.Add(m);
            }
            Console.WriteLine("\nZONA NORTE: {0}", zonaN.Count);
            if (zonaN.Count > 0)
            {
                foreach (Municipio m in zonaN)
                {
                    Console.WriteLine("\t{0, -20} {1, 10}", m.Nombre, m.Poblacion);
                }
            }
            else { Console.WriteLine("\tSin poblacion"); }
            Console.WriteLine("\nZONA CENTRO: {0}", zonaC.Count);
            if (zonaC.Count > 0)
            {
                
                foreach (Municipio m in zonaC)
                {
                    Console.WriteLine("\t{0, -20} {1, 10}", m.Nombre, m.Poblacion);
                }
            }
            else { Console.WriteLine("\tSin poblacion"); }
            Console.WriteLine("\nZONA SUR: {0}", zonaS.Count);
            if (zonaS.Count > 0)
            {
                foreach (Municipio m in zonaS)
                {
                    Console.WriteLine("\t{0, -20} {1, 10}", m.Nombre, m.Poblacion);
                }
            }
            else { Console.WriteLine("\tSin poblacion"); }
        }
        public void MunicipioPoblacionMaxima()
        {
            int max = 0;
            Municipio municipio = null;
            foreach (Municipio m in municipios)
            {
                if (m.Poblacion > max)
                {
                    max = m.Poblacion;
                    municipio = m;
                }
            }
            if (municipio != null)
            {
                Console.WriteLine("{0, -20} {1, 10}", municipio.Nombre, municipio.Poblacion);
            }
            else
            {
                Console.WriteLine("No se han ingresado municipios.");
            }
        }

        public void MunicipioPoblacionMinima()
        {
            int min = 0;
            if (municipios.Count != 0)
            {
                min = municipios[0].Poblacion;
                Municipio municipio = municipios[0];
                foreach (Municipio m in municipios)
                {
                    if (m.Poblacion < min)
                    {
                        min = m.Poblacion;
                        municipio = m;
                    }
                }
                Console.WriteLine("{0, -20} {1, 10}", municipio.Nombre, municipio.Poblacion);
            }
            else
                Console.WriteLine("No se han ingresado municipios.");
        }

        public void MustraMunicipiosPoblacionMenorAlPromedio()
        {
            double poblacionPromedio = (double) Poblacion() / municipios.Count;
            foreach (Municipio m in municipios)
            {
                if (m.Poblacion < poblacionPromedio)
                {
                    Console.WriteLine("{0, -20} {1, 10}", m.Nombre, m.Poblacion);
                }
            }
        }
    }
}
