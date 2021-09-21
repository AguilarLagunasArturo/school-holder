using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P55___PIZZERIA
{
    public class PizzaGrande : Pizza
    {
        private double precio = 109.00;

        public PizzaGrande(string estado, string descripcion = "Pizza Grande") : base(estado, descripcion) { }

        public override double Precio()
        {
            return precio;
        }
    }
}
