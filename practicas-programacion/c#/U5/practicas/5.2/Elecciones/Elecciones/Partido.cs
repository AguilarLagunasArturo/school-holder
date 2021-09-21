using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elecciones
{
    class Partido
    {
        private int votos;
        private int votosMasculino;
        private int votosFemenino;
        private string nombre;

        public int Votos { get => votos; set => votos = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int VotosMasculino { get => votosMasculino; set => votosMasculino = value; }
        public int VotosFemenino { get => votosFemenino; set => votosFemenino = value; }

        public Partido(string nombre)
        {
            this.nombre = nombre;
            votos = 0;
            votosMasculino = 0;
            votosFemenino = 0;
        }

        public double Porcentaje(int votosTotales)
        {
            if (votosTotales == 0)
                return 0;
            else
                return ((double)votos / votosTotales) * 100.0;
        }

        public double PorcentajeFemenino(int votosTotales)
        {
            if (votosTotales == 0)
                return 0;
            else
                return ((double)votosFemenino / votosTotales) * 100.0;
        }

        public double PorcentajeMasculino(int votosTotales)
        {
            if (votosTotales == 0)
                return 0;
            else
                return ((double)votosMasculino / votosTotales) * 100.0;
        }
    }
}
