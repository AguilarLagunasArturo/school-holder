using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P55___PIZZERIA
{
    public class PizzaMediana : Pizza
    {
        private double precio = 89.00;

        public PizzaMediana(string estado, string descripcion = "Pizza Mediana") : base(estado, descripcion) { }

        public override double Precio()
        {
            return precio;
        }
    }
}
